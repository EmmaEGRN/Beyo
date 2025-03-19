using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollController : MonoBehaviour
{

    public bool[] answers = new bool[4];
    public int currentDialogue = 0;
    public GameObject endPanel;
    public GameObject losePanel;
    public InfoNivel nivelParaHabilitar;
    public void Start()
    {
        losePanel.SetActive(false);
        endPanel.SetActive(false);
        displayNextDialogue();
        LiveManager.OnLoseCallBack += endLevel;
        
    }

    public void displayNextDialogue()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(currentDialogue+1 == i+1 && i != 0)
            {
                //transform.GetChild(i - 1).gameObject.SetActive(true);
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else if(currentDialogue + 1 == i + 1) {
                transform.GetChild(i).gameObject.SetActive(true);
            }else if(currentDialogue-1 == i)
            {

            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        currentDialogue++;
        if (currentDialogue == 5)
        {
            endPanel.SetActive(true);
            nivelParaHabilitar.cleared = true;
            nivelParaHabilitar.state = InfoNivel.State.enabled;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(1);

    }
    public void returnToMenu()
    {
        SceneManager.LoadScene(1);

    }


    public void endLevel()
    {



        losePanel.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
