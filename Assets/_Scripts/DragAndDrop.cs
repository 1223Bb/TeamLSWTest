using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static DragAndDrop Instance { get; private set; }

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform parent;
    private RectTransform rectTransform;
    private Vector3 startingPos;
    private InventoryItem item;
    private void Awake()
    {
        Instance = this;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        parent = transform.parent;
    }

    public void SetItem(InventoryItem item)
    {
        this.item = item;
    }

    public InventoryItem GetItem()
    {
        return item;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        UI_ItemDrag.Instance.Show(item);
        transform.SetParent(GameObject.Find("Canvas").transform);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        UI_ItemDrag.Instance.Hide();
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        startingPos = transform.position;

    }

    public void Reparent()
    {
        transform.SetParent(parent);
    }

}