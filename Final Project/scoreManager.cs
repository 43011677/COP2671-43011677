using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{

    public float gameTime = 0;
    public Text scoreText;
    public MainMenu mainMenu;

    void Update()
    {
        gameTime = Time.time - mainMenu.returnPressedAt();
        scoreText.text = "Current Score: " + gameTime.ToString("F1");
    }

    public float returnScore()
    {
        return gameTime;
    }


}

