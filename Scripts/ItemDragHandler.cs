using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //original item slot
    Transform originalParent;
    CanvasGroup canvasGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //implement for IBeginDragHandler
    public void OnBeginDrag(PointerEventData eventData){

        //throw new System.NotImplementedException();
        originalParent = transform.parent; //saves original as a parent
        transform.SetParent(transform.root); //above other canvas'
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f; //makes it semi-transparent when dragging
    }

    //implement for IDragHandler
    public void OnDrag(PointerEventData eventData){
        //throw new System.NotImplementedException();
        transform.position = eventData.position; //follows the mouse
    }

    //implement for IEndDragHandler
    public void OnEndDrag(PointerEventData eventData){
        //throw new System.NotImplementedException();
        canvasGroup.blocksRaycasts = true; //enables raycast
        canvasGroup.alpha = 1f; //disables transparency

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); //slot where item is dropped
        if(dropSlot == null){
            GameObject dropItem = eventData.pointerEnter;
            if(dropItem != null){
                dropSlot = dropItem.GetComponentInParent<Slot>();
            }
        }
        Slot originalSlot = originalParent.GetComponent<Slot>();

        if(dropSlot != null){
            if(dropSlot.currentItem != null){
                //swap items if slot is already occupied
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            } else {
                originalSlot.currentItem = null;
            }

            //move item into drop slot
            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        } else {
            //no slot under drop point
            transform.SetParent(originalParent);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //centering
    }

}
