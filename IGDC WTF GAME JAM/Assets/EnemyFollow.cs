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

    void Start()
    {
        anim = GetComponent<Animator>();
        lastPosition = transform.position;
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
    }
}
