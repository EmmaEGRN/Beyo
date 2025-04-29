using UnityEngine;
using UnityEngine.EventSystems;

public class WordAssign : MonoBehaviour, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vocabulario vocab;

    public void OnPointerClick(PointerEventData eventData)
    {
        FindAnyObjectByType<AudioManager>().Play(vocab.name);
        FindAnyObjectByType<AudioManager>().Play("click");

    }
}
