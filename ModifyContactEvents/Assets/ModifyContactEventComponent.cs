using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyContactEventComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cols = GetComponentsInChildren<Collider>();
        foreach(var c in cols)
        {
            c.hasModifiableContacts = true;
        }
    }
}
