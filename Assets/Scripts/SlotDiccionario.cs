using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotDiccionario : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vocabulario vocab;
    public Image image;
    public TextMeshProUGUI palabra;
    public TextMeshProUGUI definición;
    public TextMeshProUGUI tipo;
    void Start()
    {
        image.sprite = vocab.imagen;
        palabra.text = vocab.Parlabra;
        definición.text = vocab.Traducción;
        //tipo.text = vocab.


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
