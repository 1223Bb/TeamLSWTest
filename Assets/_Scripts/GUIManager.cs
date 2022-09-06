using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lblGold;
    [SerializeField] private GameObject pnlInventory;

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
}
