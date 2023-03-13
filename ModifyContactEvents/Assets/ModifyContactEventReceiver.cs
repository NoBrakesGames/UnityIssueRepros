using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class ModifyContactEventReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.ContactModifyEvent += ModifyEvent;
        Physics.ContactModifyEventCCD += ModifyEvent;
    }

    void ModifyEvent(PhysicsScene scene, NativeArray<ModifiableContactPair> pairs)
    {
        Debug.Log("Contact Event!");
    }
}
