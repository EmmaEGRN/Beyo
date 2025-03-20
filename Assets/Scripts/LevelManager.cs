
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int maximas;
    public Camera cam;
    public GameObject congrats;
    public GameObject losePanel;

    public CardManager carta;
    public AnswerControllelr respuesta;
    public int firstChoice;
    public int secondChoice;
    public int correctas;

    #region Singleton

    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found!");
            return;

        }
        Instance = this;
    }
    void OnDestroy()
    {
        Instance = null;
    }

    #endregion

    public delegate void OnRightAnswer(Vocabulario newVocab);
    public static event OnRightAnswer onRightAnswer;

    
    
    public void Start()
    {
        losePanel.SetActive(false);
        congrats.SetActive(false);
        correctas = 0;
        LiveManager.OnLoseCallBack += loseScreen;
    }

    public void firstCardSelected(CardManager laCarta)
    {
        carta = laCarta;
        firstChoice = carta.vocab.ID;

        if (secondChoice != 0)
        {
            CompareOptions();
        }



    }

    public void secondCardSelected(AnswerControllelr laRespuesta)
    {
        respuesta = laRespuesta;
        secondChoice = respuesta.vocab.ID;

        if (firstChoice != 0)
        {

                CompareOptions();

        }

    }


    public void CompareOptions()
    {
        if (firstChoice == secondChoice)
        {
            onRightAnswer?.Invoke(carta.vocab);
            FindAnyObjectByType<AudioManager>().Play("Achievement");
            //show correct
            carta.closeCard();
            respuesta.closeAnswer();
            firstChoice = 0;
            secondChoice = 0;
            correctas++;
        }
        else
        {
            FindAnyObjectByType<AudioManager>().Play("wrong");
            carta.GetComponent<Button>().OnDeselect(null);
            respuesta.GetComponent<Button>().OnDeselect(null);
            carta = null;
            respuesta = null;
            firstChoice = 0;
            secondChoice = 0;

            Debug.Log(firstChoice);

            LiveManager.instance.decrease();
        }
        //mostrar falso
        carta = null;
        respuesta = null;
        firstChoice = 0;
        secondChoice = 0;

    }

    public void ChangeScene()
    {
        LiveManager.instance.SaveLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restart()
    {
        SceneManager.LoadScene("LoadingScene");
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void returnToMenu()
    {
        SceneManager.LoadScene(1);

    }
    public void loseScreen()
    {
        losePanel.SetActive(true);
    }

    public void Update()
    {
        if (correctas == maximas)
        {
            congrats.SetActive(true);
        }
    }
}
