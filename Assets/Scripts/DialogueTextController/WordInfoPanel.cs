using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Events;

public class WordInfoPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Vocabulario[] vocabularioContentList;

    [SerializeField] private GameObject infoContainer;
    //TMP_Text palabraEnMaya;
    
    private TMP_Text _traduccionTMP;
    [SerializeField] private Image iconDisplay;

    public UnityVocabularyEvent addWord;

    private void Awake()
    {
        _traduccionTMP = infoContainer.GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        InteractiveTMP.OnClickOnLinkEvent += GetWordInfo;
    }

    private void OnDisable()
    {
        InteractiveTMP.OnClickOnLinkEvent -= GetWordInfo;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetWordInfo(string keyword)
    {
        if (infoContainer.gameObject.activeSelf == false)OpenHint();
        Debug.Log(keyword);

        foreach(Vocabulario word in vocabularioContentList)
        {
            //Debug.Log(GetString(word.Parlabra) == keyword);



            if (GetString(word.Parlabra) == keyword)
            {
                Debug.Log(word.Parlabra);

                Debug.Log(word.Traducción);
                _traduccionTMP.text = word.Traducción;
                iconDisplay.sprite = word.imagen;
                FindAnyObjectByType<AudioManager>().Play(word.name);

                addWord.Invoke(word);

                return;

            };
        }

    }

    public void CloseHint()
    {
        infoContainer.gameObject.SetActive(false);
    }

    public void OpenHint()
    {
       infoContainer.gameObject.SetActive(true);
    }

    public static string GetString(string str)
    {
        Regex rich = new Regex(@"<[^>]*>");

        if (rich.IsMatch(str))
        {
            str = rich.Replace(str, string.Empty);
        }

        return str;
    }
}

[System.Serializable]
public class UnityVocabularyEvent : UnityEvent<Vocabulario> { }