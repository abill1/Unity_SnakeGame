
/*****************************************************************************************
* StartGameState
*  Handles the state actions at the start of the game (Main Menu)
*  
*****************************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartGameState : SceneState
{
    //********************************************************************************
    // Constructor
    //********************************************************************************

    public StartGameState()
    {
        this.sceneType = SceneType.MAIN_SCREEN;
    }

    //********************************************************************************
    // Unity Methods
    //********************************************************************************

    void Start()
    {
        AudioManager.PlaySound(SceneThemeAudioName);
        Button quitButton = GameObject.Find("MenuScreen").transform.Find("QuitGameButton").GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);

    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    override public void NextScene()
    {
        AudioManager.StopSound(SceneThemeAudioName);
        SceneManager.LoadScene("SampleScene");

    }

    public void QuitGame()
    {
        Debug.Log("Quit Game Selected.");
        Application.Quit();
    }

}

