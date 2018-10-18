using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeHolderParent = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // disable 'raycast target' for your draggable object
        GetComponent<Image>().raycastTarget = false;

        parentToReturnTo = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // enable it back when drag is over
        GetComponent<Image>().raycastTarget = true;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider.name != null)
        {
            transform.position = hit.collider.transform.position;
            placeHolderParent = hit.collider.transform;
        }
        else
        {
            transform.position = parentToReturnTo.position;
        }
    }
}