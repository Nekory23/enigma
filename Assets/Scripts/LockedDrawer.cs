using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockedDrawer : MonoBehaviour
{
   [SerializeField] private ConfigurableJoint joint;
   [SerializeField] private float openLimit = 0.5f;

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        joint.linearLimit = new SoftJointLimit { limit = 0 };
    }

    public void unlock()
    {
        joint.linearLimit = new SoftJointLimit { limit = openLimit };
    }

    public void lockDrawer()
    {
        joint.linearLimit = new SoftJointLimit { limit = 0 };
    }
}
