using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewSecretWord : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Image imagen;
    [SerializeField] private TMP_Text palabra;
    [SerializeField] private TMP_Text traducción;

    void Start()
    {
        gameObject.SetActive(false);


        NewVocabulary.onNewWordAcquired += openCard;
    }

    private void OnDestroy()
    {
        NewVocabulary.onNewWordAcquired -= openCard;

    }

    public void appear()
    {
        //transform.LeanScale()
    }

    public void openCard(Vocabulario nuevoVocab)
    {
        imagen.sprite = nuevoVocab.imagen;
        palabra.text = nuevoVocab.PalabraRaw;
        traducción.text = nuevoVocab.Traducción;
        gameObject.SetActive(true);
        sound(nuevoVocab.name);
    }

    public void sound(string palabra)
    {
        FindAnyObjectByType<AudioManager>().Play(palabra);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
