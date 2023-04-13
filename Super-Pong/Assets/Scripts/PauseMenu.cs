using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            resumeGame();
        }
    }

    /// <Scene List>
    ///  Look to build settings under "File" tab in unity
    ///  0: Main Menu
    ///  1: Play Game
    ///  2: Instructions
    ///  3: Powerup Description
    ///  4: Right Victory Screen
    ///  5: Left Victory Screen

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void resumeGame()
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

        PlayerPrefs.SetInt("LeftPlayerScore", 0);
        PlayerPrefs.SetInt("RightPlayerScore", 0);

        //Exit the editor as well
        //EditorApplication.isPlaying = false;
    }
}
