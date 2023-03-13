using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpawner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.AddComponent<SampleOnCollisionScript>();
    }

    private void OnCollisionExit(Collision collision)
    {
        var script = collision.gameObject.GetComponent<SampleOnCollisionScript>();
        if (script)
        {
            Destroy(script);
        }
    }
}
