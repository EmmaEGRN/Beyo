using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class objectDrag : MonoBehaviour, IBeginDragHandler, IDragHandler ,IEndDragHandler
{
    public WordAssign wordAssign;
    public Transform parentPosition;
    public Image image;

    private void Start()
    {
        wordAssign = GetComponent<WordAssign>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Soud();
        parentPosition = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;



    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentPosition);
        image.raycastTarget = true;
    }

    public void Soud()
    {
        FindAnyObjectByType<AudioManager>().Play("click");
        FindAnyObjectByType<AudioManager>().Play(wordAssign.vocab.name);
    }

}
