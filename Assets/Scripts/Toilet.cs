using UnityEngine;
using UnityEngine.Events;

public class Toilet : MonoBehaviour
{
    [SerializeField] UnityEvent onSuccess;
    [SerializeField] private string tagCollider;

    private bool isOpen = false;


    void OnCollisionEnter(Collision other)
    {
        if (isOpen)
        {
            return;
        }

        if (other.gameObject.tag.Equals(tagCollider, System.StringComparison.InvariantCultureIgnoreCase))
        {
            onSuccess.Invoke();
            isOpen = true;
        }    
    }
}
