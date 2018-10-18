using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null)
            return;

        DragHandeler d = eventData.pointerDrag.GetComponent<DragHandeler>();
        if (d != null)
        {
            d.placeHolderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null)
            return;

        DragHandeler d = eventData.pointerDrag.GetComponent<DragHandeler>();
        if (d != null && d.placeHolderParent == this.transform)
        {
            d.placeHolderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

        DragHandeler d = eventData.pointerDrag.GetComponent<DragHandeler>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }
}
