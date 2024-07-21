using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public NavMeshAgent enemy;
    public Transform Player;
    private Vector3 lastPosition;
    public float movementThreshold = 0.01f; 
    public bool ismoving;
    //private Rigidbody[] rigidbodies;
    public Actor actor;

    void Start()
    {
        anim = GetComponent<Animator>();
        lastPosition = transform.position;
        //rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        enemy.SetDestination(Player.position);
        if (Vector3.Distance(lastPosition, transform.position) > movementThreshold)
        {
            // The object has moved
            ismoving=true;
            
            // Update lastPosition to the current position
            lastPosition = transform.position;
        }
        else
        {
            ismoving = false;
            //lastPosition = transform.position;
        }
        /*if(actor.currentHealth == 0||actor.currentHealth <= 0)
        {
            EnableRagdoll();
        }
        else
        {
            DisableRagdoll();
        }*/
    }
    /*public void DisableRagdoll()
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
    }*/
}
