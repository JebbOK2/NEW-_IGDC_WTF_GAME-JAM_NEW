using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody[] rigidbodies;
    public Actor actor;
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(actor.currentHealth == 0||actor.currentHealth <= 0)
        {
            EnableRagdoll();
            Debug.Log("Enabled");
        }
        else
        {
            DisableRagdoll();
            Debug.Log("Disabled");
        }
    }
    public void DisableRagdoll()
    {
        foreach(var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }
    public void EnableRagdoll()
    {
        foreach(var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
