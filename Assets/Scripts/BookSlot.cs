using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class BookSlot : MonoBehaviour
{
    public ColorCodeEnigma colorCodeEnigma;
    [SerializeField] private XRLockSocketInteractor socketInteractor;
    [SerializeField] private int index = 0;

    private void Start()
    {
        socketInteractor = GetComponent<XRLockSocketInteractor>();
        Debug.Assert(socketInteractor != null, "socketInteractor is null");
        Debug.Assert(colorCodeEnigma != null, "colorCodeEnigma is null"); 
    }

    [System.Obsolete]
    private Book getSelectedBook()
    {
        if (socketInteractor.interactablesSelected.Count > 0)
        {
            Book book = socketInteractor.selectTarget.gameObject.GetComponent<Book>();
            return book;
        }
        return null;
    }

    [System.Obsolete]
    public void setColor()
    {
        Book book = getSelectedBook();
        colorCodeEnigma.setColor(index, book.color);
    }

    public void unsetColor()
    {
        colorCodeEnigma.unsetColor(index);
    }
}
