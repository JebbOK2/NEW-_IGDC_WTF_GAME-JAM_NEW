using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public Health health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("should be working");
        if(other.tag == "Player")
        {
            Debug.Log("working");
            health.currentHealth -= 20f;
        }
        
    }
}
