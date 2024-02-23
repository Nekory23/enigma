using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class LockSocketRemoveKey : MonoBehaviour
{
    [SerializeField] private XRLockSocketInteractor socketInteractor;

    private void Start()
    {
        socketInteractor = GetComponent<XRLockSocketInteractor>();
        Debug.Assert(socketInteractor != null, "socketInteractor is null");
    }

    [System.Obsolete]
    private GameObject getSelectedKey()
    {
        if (socketInteractor.interactablesSelected.Count > 0)
        {
            GameObject key = socketInteractor.selectTarget.gameObject;
            return key;
        }
        return null;
    }

    [System.Obsolete]
    public void removeKey()
    {
        GameObject key = getSelectedKey();
        if (key != null)
        {
            key.gameObject.SetActive(false);
        }
    }
}
