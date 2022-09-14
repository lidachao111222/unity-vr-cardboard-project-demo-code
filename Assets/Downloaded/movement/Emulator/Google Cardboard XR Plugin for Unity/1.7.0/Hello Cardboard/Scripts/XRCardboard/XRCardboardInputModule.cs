using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.UI;
using System;
#if !UNITY_EDITOR
using UnityEngine.XR;
#endif

public class XRCardboardInputModule : PointerInputModule
{
    [SerializeField]
    XRCardboardInputSettings settings = default;
    [SerializeField]
    UnityFloatEvent onStartHover = default;
    [SerializeField]
    UnityEvent onEndHover = default;
    [SerializeField]
    UnityEvent onClick = default;
    [SerializeField]
    UnityEvent onHover = default;

    PointerEventData pointerEventData;
    GameObject currentTarget;
    float currentTargetClickTime = float.MaxValue;
    bool hovering;

    bool vrClicked = false; // track vr clicks to trigger interaction

    public bool isHoverEnabled = true;
    public bool isVrClickEnabled = true;

    private void Update()
    {
        if (isVrClickEnabled && Input.GetMouseButtonDown(0))
        {
            vrClicked = true;
            Debug.Log("Pressed primary button.");
            HandleLook();
            HandleSelection();
        }
    }

    public override void Process()
    {
        HandleLook();
        HandleSelection();
    }

    void HandleLook()
    {
        if (pointerEventData == null)
            pointerEventData = new PointerEventData(eventSystem);
#if UNITY_EDITOR
        pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2);
#else
        pointerEventData.position = new Vector2(XRSettings.eyeTextureWidth / 2, XRSettings.eyeTextureHeight / 2);
#endif
        pointerEventData.delta = Vector2.zero;
        var raycastResults = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, raycastResults);
        raycastResults = raycastResults.OrderBy(r => !r.module.GetComponent<GraphicRaycaster>()).ToList();
        pointerEventData.pointerCurrentRaycast = FindFirstRaycast(raycastResults);
        ProcessMove(pointerEventData);
    }

    void HandleSelection()
    {
        GameObject handler;
        try
        {
            handler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(pointerEventData.pointerEnter);
            var selectable = handler.GetComponent<Selectable>();
            if (selectable && selectable.interactable == false)
                throw new NullReferenceException();
        }
        catch (NullReferenceException)
        {
            currentTarget = null;
            StopHovering();
            return;
        }

        if (currentTarget != handler)
        {
            var gazeTime = settings.GazeTime;
            currentTarget = handler;
            currentTargetClickTime = Time.realtimeSinceStartup + gazeTime;
            if (hovering)
                StopHovering();
            hovering = true;
            vrClicked = false;

            if (isHoverEnabled)
                onStartHover?.Invoke(gazeTime);
            else if(!isHoverEnabled && isVrClickEnabled)
            {
                onHover?.Invoke();
            }
        }

        if (Time.realtimeSinceStartup > currentTargetClickTime || Input.GetButtonDown(settings.ClickInput) || vrClicked == true)
        {
            vrClicked = false;
            ExecuteEvents.ExecuteHierarchy(currentTarget, pointerEventData, ExecuteEvents.pointerClickHandler);
            currentTargetClickTime = float.MaxValue;
            onClick?.Invoke();
            StopHovering();
        }
    }

    void StopHovering()
    {
        if (!hovering)
            return;
        hovering = false;
        vrClicked = false;
        onEndHover?.Invoke();
    }
}