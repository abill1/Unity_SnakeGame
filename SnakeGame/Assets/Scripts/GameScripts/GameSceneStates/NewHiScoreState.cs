
/*****************************************************************************************
* NewHiScoreState
*  Handles the state actions when a new hi score is achieved 
*  
*****************************************************************************************/

using UnityEngine.SceneManagement;

public class NewHiScoreState : SceneState
{
    //********************************************************************************
    // Constructor
    //********************************************************************************

    public NewHiScoreState()
    {
        this.sceneType = SceneType.NEW_HI_SCORE;
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

