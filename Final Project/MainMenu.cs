using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject instructionsMenu;
    public GameObject pauseMenu;
    public GameObject endCredits;
    public float pressedAt;
    public scoreManager scoreManager;
    public float highScore = 0;
    public Text scoreText;
    

    void Start()
    {
        //updateScore();
        startMenu();
    }

    void updateScore()
    {
        /*
        if (scoreManager.reutrnScore() > highScore)
        {
         highScore = scoreManager.returnScore();

         scoreText.text = "High Score: " + highScore.ToString("F1") + "Seconds";
        }
        */
    }

    public void startMenu()
    {
        Time.timeScale = 0;
        endCredits.SetActive(false);
        titleScreen.SetActive(true);
        instructionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        pressedAt = Time.time;
    }

    public float returnPressedAt()
    {
        return pressedAt;
    }
    public void StartGame()
    {
        titleScreen.SetActive(false);
        Time.timeScale = 1; 
    }

    public void infoButton()
    {
        titleScreen.SetActive(false);
        instructionsMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void CloseTextWindow()
    {

        instructionsMenu.SetActive(false);
        titleScreen.SetActive(true);

    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void endScreen()
    {
        endCredits.SetActive(true);
    }


}
