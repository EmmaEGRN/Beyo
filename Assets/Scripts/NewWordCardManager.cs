using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewWordCardManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Image imagen;
    [SerializeField] private TMP_Text palabra;
    [SerializeField] private TMP_Text traducción;
    public Vocabulario vocab;


    void Start()
    {
        gameObject.SetActive(false);

        imagen.sprite = vocab.imagen;
        palabra.text = vocab.PalabraRaw;
        traducción.text = vocab.Traducción;
        NewVocabulary.onNewWordAcquired += openCard;
        NewVocabulary.onNewWordAcquired += sound;
    }

    private void OnDestroy()
    {
        NewVocabulary.onNewWordAcquired -= openCard;
        NewVocabulary.onNewWordAcquired -= sound;

    }

    public void appear(){
        //transform.LeanScale()
        }

    public void openCard()
    {
        gameObject.SetActive(true);
    }

    public void sound()
    {
        FindAnyObjectByType<AudioManager>().Play(vocab.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
