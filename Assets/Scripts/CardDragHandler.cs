using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform homeParent;
    private Transform currentParent;
    private Vector2 originalPosition;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private LayoutGroup handLayout;
    private LayoutElement layoutElement;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        layoutElement = GetComponent<LayoutElement>();
        if (layoutElement == null)
        {
            layoutElement = gameObject.AddComponent<LayoutElement>();
        }
    }

    private void Start()
    {
        homeParent = transform.parent;
        currentParent = homeParent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (homeParent != null)
        {
            handLayout = homeParent.GetComponent<LayoutGroup>();
        }

        if (handLayout != null)
        {
            handLayout.enabled = false;
        }

        originalPosition = transform.localPosition;

        // Swap to the UI when dragging so it shows above all
        transform.SetParent(canvas.transform, true);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Show the card while being dragged
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Save the correct size (could probably be removed later)
        Vector2 savedSize = GetComponent<RectTransform>().sizeDelta;

        GameObject dropTarget = eventData.pointerEnter;


        // If you don't drop it in a card slot, put it back in the Hand
        if (dropTarget != null && dropTarget.CompareTag("CardSlot"))
        {
            transform.SetParent(dropTarget.transform, false);
            currentParent = dropTarget.transform;
        }
        else
        {
            transform.SetParent(homeParent, false);
            currentParent = homeParent;
        }

        // Tell layout groups to respect this size (could probably be removed later)
        layoutElement.preferredWidth = savedSize.x;
        layoutElement.preferredHeight = savedSize.y;
        layoutElement.flexibleWidth = 0;
        layoutElement.flexibleHeight = 0;

        // Set the size (could probably be removed later)
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = savedSize;
        rt.localScale = Vector3.one;
        rt.localPosition = Vector3.zero;
        if (handLayout != null)
        {
            handLayout.enabled = true;
            LayoutRebuilder.ForceRebuildLayoutImmediate(handLayout.GetComponent<RectTransform>());
        }

        // Force rebuild on the new parent (could probably be removed later)
        LayoutGroup parentLayout = currentParent.GetComponent<LayoutGroup>();
        if (parentLayout != null)
            LayoutRebuilder.ForceRebuildLayoutImmediate(parentLayout.GetComponent<RectTransform>());
    }
}
