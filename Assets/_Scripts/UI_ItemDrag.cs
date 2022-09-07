using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ItemDrag : MonoBehaviour {

    public static UI_ItemDrag Instance { get; private set; }

    private Canvas canvas;
    private RectTransform rectTransform;
    private RectTransform parentRectTransform;
    private CanvasGroup canvasGroup;
    private Image image;
    private InventoryItem item;
    [SerializeField] PlayerInputHandler input;

    private void Awake() {
        Instance = this;

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        image = transform.Find("Image").GetComponent<Image>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();

        Hide();
    }

    private void Update() {
        UpdatePosition();
    }

    private void UpdatePosition() {
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, null, out Vector2 localPoint);
        Vector2 mousePosition;
        mousePosition = input.GetMousePosition();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, mousePosition, null, out Vector2 localPoint);
        transform.localPosition = localPoint;
    }

    public InventoryItem GetItem() {
        return item;
    }

    public void SetItem(InventoryItem item) {
        this.item = item;
    }

    public void SetSprite(Sprite sprite) {
        image.sprite = sprite;
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Show(InventoryItem item) {
        gameObject.SetActive(true);

        SetItem(item);
        //SetSprite(item.GetSprite());
        UpdatePosition();
    }

}
