using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiveManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Singleton

    public static LiveManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found!");
           
            return;

        }
        instance = this;
    }
    void OnDestroy()
    {
        instance = null;
        OnLoseCallBack = null;
    }

    #endregion
    public spriteChangerHearts spriteChangerHearts;

    [SerializeField] InfoNivel infoNivel;

    public delegate void OnLose();
    public static event OnLose OnLoseCallBack;
    //[SerializeField]TMP_Text vidasUI;

    [SerializeField] int liveCounter;
    [SerializeField] int SpriteCounter;

    void Start()
    {

        SetAllInfo();

    }

    public void SetAllInfo()
    {
        liveCounter = infoNivel.numeroDeVidas;

      //  vidasUI.text = liveCounter.ToString();

        ConvertLives(liveCounter);
    }

    // Update is called once per frame
    public void ConvertLives(int liveCounter)
    {
        switch (liveCounter)
        {
            case (0):
                SpriteCounter = 3;
                break;
            case (1):
                SpriteCounter = 2;
                break;
            case (2):
                SpriteCounter = 1;
                break;
            case (3):
                SpriteCounter = 0;
                break;
            default:
                SpriteCounter = 0;
                break;
        }
        changeSprite(SpriteCounter);
    }

    public void changeSprite(int SpriteCounter)
    {
        spriteChangerHearts.ChangeSpecificSprite(SpriteCounter);

    }

    public void SaveLives()
    {
        infoNivel.numeroDeVidas = liveCounter; 
    }

    public void decrease()
    {
        liveCounter--;
        SpriteCounter++;
        spriteChangerHearts.ChangeSpecificSprite(SpriteCounter);
        //vidasUI.text = liveCounter.ToString();
        Debug.Log(liveCounter);

        if (liveCounter == 0)
        {
            Debug.Log("You Lost!");
            OnLoseCallBack?.Invoke();
            liveCounter = infoNivel.numeroDefault;            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }


}
