
/*****************************************************************************************
* SceneState
*  A base class to be used with each scene to manage the state of the scene. 
*  When a condition is met to change the scene due to a change in the game state,
*  the derived classes of this class will update the game state. 
*  
*****************************************************************************************/

using UnityEngine;

public abstract class SceneState : MonoBehaviour
{
    //********************************************************************************
    // Enum of Scene Types
    //********************************************************************************

    public enum SceneType : int
    {
        MAIN_SCREEN,
        GAME_LEVEL,
        END_SCREEN,
        NEW_HI_SCORE
    }

    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] protected string SceneThemeAudioName;

    //********************************************************************************
    // Member Variables
    //********************************************************************************

    protected SceneType sceneType;

    //********************************************************************************
    // Utility
    //********************************************************************************

    public void StopSceneThemeMusic()
    {
        AudioManager.StopSound(SceneThemeAudioName);

    }

    //********************************************************************************
    // Getters
    //********************************************************************************

    public SceneType GetSceneType() { return sceneType; }
    

    //********************************************************************************
    // Abstract Methods
    //********************************************************************************

    abstract public void NextScene();

    //********************************************************************************
    // Private Methods
    //********************************************************************************

  

}

