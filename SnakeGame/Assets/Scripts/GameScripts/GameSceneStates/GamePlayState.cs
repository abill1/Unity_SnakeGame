
/*****************************************************************************************
* GamePlayState
*  Handles the state actions during game play
*  
*****************************************************************************************/

using UnityEngine.SceneManagement;

public class GamePlayState : SceneState
{
    //********************************************************************************
    // Constructor
    //********************************************************************************

    public GamePlayState()
    {
        this.sceneType = SceneType.GAME_LEVEL;

    }

    //********************************************************************************
    // Unity Methods
    //********************************************************************************

    void Start()
    {
        AudioManager.PlaySound(SceneThemeAudioName);

    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    override public void NextScene()
    {
        AudioManager.StopSound(SceneThemeAudioName);
        SceneManager.LoadScene("EndGame");
        

    }

}
