using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    public float currentHealth = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
