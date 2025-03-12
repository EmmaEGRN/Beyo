using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject congrats;
    public GameObject losePanel;

    private void Start()
    {
        losePanel.SetActive(false);
        congrats.SetActive(false);
    }
    public void CongratulationScreen()
    {
        congrats.SetActive(true);
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene(1);

    }
    public void loseScreen()
    {
        losePanel.SetActive(true);
    }

    public void finishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
