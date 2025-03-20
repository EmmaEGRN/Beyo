using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelSetter : MonoBehaviour
{
    [SerializeField] TMP_Text traducci�n;
    [SerializeField] Image sprite;
    [SerializeField] Sentences sentenceToCheck;
    [SerializeField] AnswerCheck answerCheck;
    

    void Start()
    {
        traducci�n.text = sentenceToCheck.traducci�n;
        answerCheck.sentenceToCheck = sentenceToCheck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
