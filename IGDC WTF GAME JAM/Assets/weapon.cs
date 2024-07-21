using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshCollider collider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableCollider()
    {
        collider.enabled = true;
    }
    public void DisableCollider()
    {
        collider.enabled = false;
    }
}
