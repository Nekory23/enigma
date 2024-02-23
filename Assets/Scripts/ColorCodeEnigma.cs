using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorCodeEnigma : MonoBehaviour
{
    public UnityEvent onSuccess;
    [SerializeField] private Book.Color[] colorCodeModel;
    [SerializeField] private Book.Color[] colorCode;

    void Start()
    {
        colorCode = new Book.Color[colorCodeModel.Length];
        for (int i = 0; i < colorCodeModel.Length; i++)
        {
            colorCode[i] = Book.Color.Blank;
        }
    }

    private void checkSuccess()
    {
        for (int i = 0; i < colorCodeModel.Length; i++)
        {
            if (colorCode[i] != colorCodeModel[i])
            {
                return;
            }
        }
        onSuccess.Invoke();
    }

    public void setColor(int index, Book.Color color)
    {
        colorCode[index] = color;
        checkSuccess();
    }

    public void unsetColor(int index)
    {
        colorCode[index] = Book.Color.Blank;
    }
}
