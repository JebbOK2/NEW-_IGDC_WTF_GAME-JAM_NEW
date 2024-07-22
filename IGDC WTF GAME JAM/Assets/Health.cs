using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    public float currentHealth = 100;
    [Header("Healthbar")]
    public healthbar bar;
    void Start()
    {
        bar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        bar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Health")
        {
            currentHealth =  maxHealth;
            Destroy(other.gameObject);
        }
        
    }
}
