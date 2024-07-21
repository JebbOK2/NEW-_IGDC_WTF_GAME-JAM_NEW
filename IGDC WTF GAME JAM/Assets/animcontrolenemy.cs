using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animcontrolenemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public EnemyFollow enemyfollow;
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyfollow.ismoving)
        {
            
            anim.SetBool("ismoving",true);
        }
        if(!enemyfollow.ismoving)
        {
            
            anim.SetBool("ismoving",false);
        }
    }
}
