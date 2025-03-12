using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class AnswerControllelr : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI palabra;
    public Vocabulario vocab;
    public GameObject estaRespuesta;

    void Start()
    {
        palabra.text = vocab.Traducción;
    }

    public void Selection()
    {
        FindAnyObjectByType<AudioManager>().Play(vocab.name);
        LevelManager.Instance.secondCardSelected(this);
    }

    // Update is called once per frame
    public void closeAnswer()
    {
        estaRespuesta.SetActive(false);
    }
}
