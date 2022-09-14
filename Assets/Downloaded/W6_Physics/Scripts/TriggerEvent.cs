using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    void OnTriggerEnter()
	{
		Debug.Log("Hello");
	}

	void OnTriggerStay()
	{
		Debug.Log("Why are you staying here so long?");
	}

	void OnTriggerExit()
	{
		Debug.Log("Okay bye!");
	}
}
