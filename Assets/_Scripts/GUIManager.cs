using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lblGold;
    [SerializeField] private GameObject pnlInventory;
    [SerializeField] private GameObject playerInventoryContainer;
    [SerializeField] private GameObject itemSlotPrefab;

    private Inventory playerInventory;
    private Vector2 startingInventoryPosition, desiredInventoryPosition;
    private bool isInventoryShowing = false;
    public void SetGoldAmmount(int goldAmmount)
    {
        lblGold.text = goldAmmount.ToString();
    }

    private void Start()
    {
        CalculatePositions();
        SetPositions();

    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        playerInventory.onInventoryUpdate -= RefreshPlayerInventory;
    }

    public void SetPlayerInventory(Inventory playerInventory)
    {
        this.playerInventory = playerInventory;
        playerInventory.onInventoryUpdate += RefreshPlayerInventory;
        RefreshPlayerInventory();
    }

    private void CalculatePositions()
    {
        startingInventoryPosition = Camera.main.ViewportToScreenPoint(new Vector3(1.25f, 0.5f, 0));
        desiredInventoryPosition = Camera.main.ViewportToScreenPoint(new Vector3(0.75f,0.5f,0));
    }

    private void SetPositions()
    {
        pnlInventory.transform.position = startingInventoryPosition;
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

    private void RefreshPlayerInventory()
    {
        foreach(Transform child in playerInventoryContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(InventoryItem item in playerInventory.GetItemList())
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, playerInventoryContainer.transform);
            Image image = itemSlot.transform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();

        }
    }
}
