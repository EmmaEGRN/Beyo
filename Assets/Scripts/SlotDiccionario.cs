using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotDiccionario : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vocabulario vocab;
    public Image image;
    public TextMeshProUGUI palabra;
    public TextMeshProUGUI definici�n;
    public TextMeshProUGUI tipo;
    void Start()
    {
        image.sprite = vocab.imagen;
        palabra.text = vocab.Parlabra;
        definici�n.text = vocab.Traducci�n;
        //tipo.text = vocab.


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
