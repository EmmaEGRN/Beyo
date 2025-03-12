using UnityEngine;
using UnityEngine.EventSystems;
public class WordContainer : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        objectDrag objectDrag = dropped.GetComponent<objectDrag>();
        objectDrag.parentPosition = transform;
        Debug.Log(transform.name);
    }
}
