using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerCheck : MonoBehaviour
{
    public int[] rightAnswers;
    public int[] ids;
    public delegate void ShowResult();
    public GameObject answerPanel;
    public GameObject answerContainer;
    public GameObject checkButton;
    public GameObject congratulations;
    public Image panel;
    public bool right;
    public int rightAsnwerCount;
    public ScrollController scrollController;
    ShowResult showResult;



    public void Start()
    {
        panel = answerPanel.GetComponent<Image>();
    }

    public void CheckAnswer()
    {
        rightAsnwerCount = 0;
        Debug.Log(transform.childCount.ToString() + " " + rightAnswers.Length.ToString());
        ids = new int[rightAnswers.Length];
        if (transform.childCount == rightAnswers.Length)
        {
            for (int i = 0; i < rightAnswers.Length; i++)
            {
                ids[i] = transform.GetChild(i).GetComponent<WordAssign>().vocab.ID;
                if (rightAnswers[i] == ids[i])
                {
                    
                    rightAsnwerCount++;
                }
            }
        }
        if (rightAsnwerCount == rightAnswers.Length)
        {
            showResult = congratulate;
        }
        else
        {
            showResult = correct;
        }

        showResult();
    }
public void congratulate()
    {
        FindAnyObjectByType<AudioManager>().Play("Achievement");
        panel.GetComponent<spriteChanger>().SetAsGood();
        right = true;
        scrollController.displayNextDialogue();

    }
public void correct()
    {
        FindAnyObjectByType<AudioManager>().Play("wrong");
        panel.GetComponent<spriteChanger>().SetAsFalse();
        LiveManager.instance.decrease();
        right = false;
        //scrollController.displayNextDialogue();
    }

}


