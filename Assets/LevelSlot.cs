using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InfoNivel thisLevel;
    public TMP_Text nombreDelNivel;
    public TMP_Text numeroDelNivel;
    public Image backgroundImage;
    public bool cleared;
    void Start()
    {
        numeroDelNivel.text = "Nivel " + thisLevel.numeroDeNivel +":";
        nombreDelNivel.text = thisLevel.nombreDeNivel;
        cleared = thisLevel.cleared;

        if (!cleared)
        {
            backgroundImage.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterLevel()
    {
        SceneManager.LoadScene(thisLevel.startScene);
    }
}
