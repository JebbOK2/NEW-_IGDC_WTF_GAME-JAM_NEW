using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody[] rigidbodies;
    public Actor actor;
    private Animator anim;
    public EnemyFollow enem;
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(actor.currentHealth == 0||actor.currentHealth <= 0)
        {
            anim.enabled = false;
            EnableRagdoll();
            Debug.Log("Enabled");
            enem.enabled = false;
            actor.enabled = false;
        }
        else
        {
            DisableRagdoll();
            Debug.Log("Disabled");
            anim.enabled = true;
            enem.enabled = true;
            actor.enabled = true;
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
