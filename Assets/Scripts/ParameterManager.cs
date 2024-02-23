using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ParameterManager : MonoBehaviour
{
    public ActionBasedController leftHand;

    private void Update()
    {
        // Get the value for the paramater button on the left hand
        bool parameterButton = leftHand.selectAction.action.ReadValue<bool>();
        // If the parameter button is pressed
        Debug.Log("Parameter button: " + parameterButton);
    }
}
