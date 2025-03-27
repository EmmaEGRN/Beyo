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

    public delegate void AddThisWord(Vocabulario newVocab);
    public static event AddThisWord addThisWord;
   
    private void OnEnable()
    {
        addThisWord?.Invoke(vocab);
    }
    void Start()
    {
        setContent();
    }

    public void setContent()
    {
        imagen.sprite = vocab.imagen;
        palabra.text = vocab.PalabraRaw;
        traducción.text = vocab.Traducción;
    }

    public void Selection()
    {
        FindAnyObjectByType<AudioManager>().Play(vocab.name);
    }

}
