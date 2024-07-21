using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeMahcine : MonoBehaviour
{
    public playerInv inv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inv.ElementsFound == 3)
        {
            SceneManager.LoadScene(2);
        }
    }
}
