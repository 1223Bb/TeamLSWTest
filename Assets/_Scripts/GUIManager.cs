using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public static GUIManager Instance;

    [SerializeField] private TextMeshProUGUI lblGold;
    [SerializeField] private GameObject pnlInventory, pnlShopInventory;
    [SerializeField] private GameObject playerInventoryContainer;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private PlayerInventory playerInventory;
    private Inventory playerItemInventory;


    private Vector2 startingInventoryPosition, desiredInventoryPosition, startingShopInventoryPosition, desiredShopInventoryPosition;
    private bool isInventoryShowing = false, isShopInventoryShowing = false;
    public void SetGoldAmmount(int goldAmmount)
    {
        lblGold.text = goldAmmount.ToString();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CalculatePositions();
        SetPositions();
        playerItemInventory = playerInventory.GetInventory();
        playerItemInventory.UpdateMoneyUI();
        RefreshPlayerInventory();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    private void CalculatePositions()
    {
        startingInventoryPosition = Camera.main.ViewportToScreenPoint(new Vector3(1.25f, 0.5f, 0));
        desiredInventoryPosition = Camera.main.ViewportToScreenPoint(new Vector3(0.75f,0.5f,0));
        startingShopInventoryPosition = Camera.main.ViewportToScreenPoint(new Vector3(-0.25f, 0.5f, 0));
        desiredShopInventoryPosition = Camera.main.ViewportToScreenPoint(new Vector3(0.25f, 0.5f, 0));
    }

    private void SetPositions()
    {
        pnlInventory.transform.position = startingInventoryPosition;
    }

    public void ToggleShopInventoryUI()
    {
        isShopInventoryShowing = !isShopInventoryShowing;
        LeanTween.cancel(pnlShopInventory);
        if (isShopInventoryShowing)
        {
            LeanTween.move(pnlShopInventory, desiredShopInventoryPosition, 0.7f).setEaseOutElastic();
        }
        else
        {
            LeanTween.move(pnlShopInventory, startingShopInventoryPosition, 0.7f).setEaseOutCubic();
        }
        ToggleInventoryUI();
    }

    public void ToggleInventoryUI()
    {
        isInventoryShowing = !isInventoryShowing;
        LeanTween.cancel(pnlInventory);
        if(isInventoryShowing)
        {
            LeanTween.move(pnlInventory, desiredInventoryPosition, 0.7f).setEaseOutElastic();
        }
        else
        {
            LeanTween.move(pnlInventory, startingInventoryPosition, 0.7f).setEaseOutCubic();
        }
    }

    //public void SetPlayerInventory(Inventory playerInventory)
    //{
    //    this.playerInventory = playerInventory;
    //}

    public void RefreshPlayerInventory()
    {
        for(int i = playerInventoryContainer.transform.childCount; i>0;i--)
        {
            Destroy(playerInventoryContainer.transform.GetChild(0).gameObject);
        }
        if (playerItemInventory != null)
        {
            for(int i = 0; i < playerItemInventory.GetCount(); i++)
            {
                GameObject itemSlotGameObject = Instantiate(itemSlotPrefab, playerInventoryContainer.transform);
                ItemSlot itemSlot = itemSlotGameObject.GetComponent<ItemSlot>();
                //Debug.Log("is itemSlot null " + itemSlot == null);
                //Debug.Log("Item to be set" + item);
                itemSlot.SetItem(playerItemInventory.GetItemList()[i]);
            }
        }
    }
}
