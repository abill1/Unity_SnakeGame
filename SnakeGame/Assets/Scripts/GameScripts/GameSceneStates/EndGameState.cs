
/*****************************************************************************************
* EndGameState
*  Handles the state actions of the end of the game
*  
*****************************************************************************************/

using UnityEngine.SceneManagement;

public class EndGameState : SceneState
{
    //********************************************************************************
    // Constructor
    //********************************************************************************

    public EndGameState()
    {
        this.sceneType = SceneType.END_SCREEN;
    }

    //********************************************************************************
    // Unity Methods
    //********************************************************************************

    void Start()
    {
        LeaderBoard_SO.Load();
        LeaderBoard_SO.PopulateTable();
        AudioManager.PlaySound(SceneThemeAudioName);

    }

    private void OnDestroy()
    {
        LeaderBoard_SO.Save();
    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    override public void NextScene()
    {
        AudioManager.StopSound(SceneThemeAudioName);
        LeaderBoard_SO.Save();
        SceneManager.LoadScene("MainMenu");

    }

}

