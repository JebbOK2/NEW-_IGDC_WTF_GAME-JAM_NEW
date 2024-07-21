using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInv : MonoBehaviour
{
    [Header("general")]
    public List<itemType> invlist;
    public int selecteditem = 0;
    public float playerReach;
    [SerializeField] GameObject throwItemGO;

    [Space(20)]
    [Header("Keys")]
    [SerializeField] KeyCode throwItemKey;
    [SerializeField] KeyCode pickItemKey;

    [Space(20)]
    [Header("item gameobjects")]
    [SerializeField] GameObject Sworditem;
    [SerializeField] GameObject Axeitem;
    [SerializeField] GameObject SciFiitem;

    [SerializeField] Camera cam;

    [SerializeField] GameObject pickupText;

    [Space(20)]
    [Header("item prefabs")]
    [SerializeField] GameObject sword_prefab;
    [SerializeField] GameObject axe_prefab;
    [SerializeField] GameObject sciFi_prefab;

    [Space(20)]
    [Header("UI")]
    [SerializeField] Image[] InvSlotImage = new Image[6];
    [SerializeField] Image[] InvBGImage = new Image[6];
    [SerializeField] Sprite emptySlotSprite;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };
    private Dictionary<itemType, GameObject> itemInstantiate = new Dictionary<itemType, GameObject>() { };

    private Ipickable currentOutlinedItem = null;

    // Start is called before the first frame update
    void Start()
    {
        itemSetActive.Add(itemType.Sword, Sworditem);
        itemSetActive.Add(itemType.Axe, Axeitem);
        itemSetActive.Add(itemType.SciFiSword, SciFiitem);

        itemInstantiate.Add(itemType.Sword, sword_prefab);
        itemInstantiate.Add(itemType.Axe, axe_prefab);
        itemInstantiate.Add(itemType.SciFiSword, sciFi_prefab);

        NewItemSelected();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, playerReach))
        {
            Ipickable item = hitInfo.collider.GetComponent<Ipickable>();
            if (item != null)
            {
                if (currentOutlinedItem != null && currentOutlinedItem != item)
                {
                    currentOutlinedItem.DisableOutline();
                }

                item.EnableOutline();
                currentOutlinedItem = item;
                pickupText.SetActive(true);

                if (Input.GetKeyDown(pickItemKey))
                {
                    invlist.Add(hitInfo.collider.GetComponent<itemPickable>().itemScriptable.item_type);
                    item.DisableOutline();
                    item.PickItem(); //just destroy from item pick script
                    currentOutlinedItem = null;
                }
            }
            else
            {
                if (currentOutlinedItem != null)
                {
                    currentOutlinedItem.DisableOutline();
                    currentOutlinedItem = null;
                }
                pickupText.SetActive(false);
            }
        }
        else
        {
            if (currentOutlinedItem != null)
            {
                currentOutlinedItem.DisableOutline();
                currentOutlinedItem = null;
            }
            pickupText.SetActive(false);
        }

        if (Input.GetKeyDown(throwItemKey) && invlist.Count > 0)
        {
            Instantiate(itemInstantiate[invlist[selecteditem]], position: throwItemGO.transform.position, new Quaternion());
            invlist.RemoveAt(selecteditem);
            if (selecteditem != 0)
            {
                selecteditem -= 1;
            }
            NewItemSelected();
        }

        // UI
        for (int i = 0; i < 6; i++)
        {
            if (i < invlist.Count)
            {
                InvSlotImage[i].sprite = itemSetActive[invlist[i]].GetComponent<item>().ScriptableObject.item_sprite;
            }
            else
            {
                InvSlotImage[i].sprite = emptySlotSprite;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && invlist.Count > 0)
        {
            selecteditem = 0;
            NewItemSelected();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && invlist.Count > 1)
        {
            selecteditem = 1;
            NewItemSelected();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && invlist.Count > 2)
        {
            selecteditem = 2;
            NewItemSelected();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && invlist.Count > 3)
        {
            selecteditem = 3;
            NewItemSelected();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && invlist.Count > 4)
        {
            selecteditem = 4;
            NewItemSelected();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && invlist.Count > 5)
        {
            selecteditem = 5;
            NewItemSelected();
        }
    }

    public void NewItemSelected()
    {
        Axeitem.SetActive(false);
        Sworditem.SetActive(false);
        SciFiitem.SetActive(false);
        if (invlist.Count > 0)
        {
            GameObject selectedItemObject = itemSetActive[invlist[selecteditem]];
            selectedItemObject.SetActive(true);
        }
    }
}

public interface Ipickable
{
    void PickItem();
    void DisableOutline();
    void EnableOutline();
}
