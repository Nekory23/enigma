using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Safe : MonoBehaviour
{
    [SerializeField] private int[] code = new int[4];
    [SerializeField] private GameObject[] panels;
    [SerializeField] private UnityEvent onSuccess;

    [SerializeField] private int[] currentCode = new int[4];


    private void Start()
    {
        for (int i = 0; i < code.Length; i++)
        {
            currentCode[i] = 1;
        }
    }

    public void RotateKnob(int knobIndex)
    {
        Transform knobTransform = panels[knobIndex].transform.Find("Dial/Dial Visuals/Knob");
        Vector3 knobRotation = knobTransform.transform.localEulerAngles;
        int number = Mathf.RoundToInt(knobRotation.y) / 40 + 1;

        currentCode[knobIndex] = number;
        panels[knobIndex].transform.Find("Label").GetComponent<TextMeshPro>().text = number.ToString();
    }

    public void checkSuccess()
    {
        if (currentCode[0] == code[0] && currentCode[1] == code[1] && currentCode[2] == code[2] && currentCode[3] == code[3])
        {
            onSuccess.Invoke();
        }
    }
}
