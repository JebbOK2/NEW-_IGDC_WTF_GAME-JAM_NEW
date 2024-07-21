using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickable : MonoBehaviour, Ipickable
{
    Outline outline;
    public itemSo itemScriptable;

    private void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }
    public void PickItem()
    {
        Destroy(gameObject);
    }
    public void DisableOutline()
    {
        outline.enabled = false;
    }
    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
