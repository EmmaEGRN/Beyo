using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelSetter : MonoBehaviour
{
    [SerializeField] TMP_Text traducción;
    [SerializeField] Image sprite;
    [SerializeField] Sentences sentenceToCheck;
    [SerializeField] AnswerCheck answerCheck;
    

    void Start()
    {
        traducción.text = sentenceToCheck.traducción;
        answerCheck.sentenceToCheck = sentenceToCheck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
