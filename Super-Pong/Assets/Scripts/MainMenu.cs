using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    /// <Scene List>
    ///  Look to build settings under "File" tab in unity
    ///  0: Main Menu
    ///  1: Play Game
    ///  2: Instructions
    ///  3: Powerup Description
    ///  4: Quits the game

    public void playGame()
    {
        SceneManager.LoadScene(1);  
    }

    public void loadInstructions()
    {
        SceneManager.LoadScene(2);
    }
    public void explainPowerups()
    {
        SceneManager.LoadScene(3);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
