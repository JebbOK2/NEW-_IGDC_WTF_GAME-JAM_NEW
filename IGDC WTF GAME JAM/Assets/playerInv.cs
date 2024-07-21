using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInv : MonoBehaviour
{
    [Header("general")]
    public List<itemType> invlist;
    public int selecteditem = 0;
    public int ElementsFound=0;
    public float playerReach;
    [SerializeField] GameObject throwItemGO;

    [Space(20)]
    [Header("Keys")]
    [SerializeField] KeyCode throwItemKey;
    [SerializeField] KeyCode pickItemKey;

    [Space(20)]
    [Header("item gameobjects")] // in hand
    [SerializeField] GameObject Sworditem;
    [SerializeField] GameObject Axeitem;
    [SerializeField] GameObject SciFiitem;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject element1;
    [SerializeField] GameObject element2;
    [SerializeField] GameObject element3;

    [SerializeField] Camera cam;

    [SerializeField] GameObject pickupText;

    [Space(20)]
    [Header("item prefabs")]
    [SerializeField] GameObject sword_prefab;
    [SerializeField] GameObject axe_prefab;
    [SerializeField] GameObject sciFi_prefab;
    [SerializeField] GameObject paper_prefab;
    [SerializeField] GameObject element1_prefab;
    [SerializeField] GameObject element2_prefab;
    [SerializeField] GameObject element3_prefab;

    [Space(20)]
    [Header("UI")]
    [SerializeField] Image[] InvSlotImage = new Image[6];
    [SerializeField] Image[] InvBGImage = new Image[6];
    [SerializeField] Sprite emptySlotSprite;
    [SerializeField] GameObject imagePaper;

    
    private GameObject selectedItemObject;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };
    private Dictionary<itemType, GameObject> itemInstantiate = new Dictionary<itemType, GameObject>() { };

    private Ipickable currentOutlinedItem = null;

    // Start is called before the first frame update
    void Start()
    {
        //setactive in hand
        itemSetActive.Add(itemType.Sword, Sworditem);
        itemSetActive.Add(itemType.Axe, Axeitem);
        itemSetActive.Add(itemType.SciFiSword, SciFiitem);
        itemSetActive.Add(itemType.paper, paper);
        itemSetActive.Add(itemType.element1, element1);
        itemSetActive.Add(itemType.element2, element2);
        itemSetActive.Add(itemType.element3, element3);

        itemInstantiate.Add(itemType.Sword, sword_prefab);
        itemInstantiate.Add(itemType.Axe, axe_prefab);
        itemInstantiate.Add(itemType.SciFiSword, sciFi_prefab);
        itemInstantiate.Add(itemType.paper, paper_prefab);
        itemInstantiate.Add(itemType.element1, element1);
        itemInstantiate.Add(itemType.element2, element2);
        itemInstantiate.Add(itemType.element3, element3);


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
                    if(hitInfo.collider.GetComponent<itemPickable>().itemScriptable.item_type == itemType.element1 || hitInfo.collider.GetComponent<itemPickable>().itemScriptable.item_type == itemType.element2 || hitInfo.collider.GetComponent<itemPickable>().itemScriptable.item_type == itemType.element3)
                    {
                        ElementsFound += 1;
                    }
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
        if (selectedItemObject != null && selectedItemObject.name == "paper")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                imagePaper.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                imagePaper.SetActive(false);
            }
        }
        else
        {
            imagePaper.SetActive(false);
        }
    }

    public void NewItemSelected()
    {
        Axeitem.SetActive(false);
        Sworditem.SetActive(false);
        SciFiitem.SetActive(false);
        paper.SetActive(false);
        element1.SetActive(false);
        element2.SetActive(false);
        element3.SetActive(false);
        if (invlist.Count > 0)
        {
            selectedItemObject = itemSetActive[invlist[selecteditem]];
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
