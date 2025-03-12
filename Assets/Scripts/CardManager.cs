using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image imagen;
    public TextMeshProUGUI palabra;
    public Vocabulario vocab;
    public GameObject estaCarta;

    public bool wasSelected;

    void Start()
    {
        wasSelected = false;
        imagen.sprite = vocab.imagen;
        palabra.text = vocab.PalabraRaw;
        estaCarta.SetActive(true);
    }

    public void Selection()
    {
        FindAnyObjectByType<AudioManager>().Play(vocab.name);
        LevelManager.Instance.firstCardSelected(this);
    }

    public void closeCard ()
    {
        estaCarta.SetActive(false);
    }

}
