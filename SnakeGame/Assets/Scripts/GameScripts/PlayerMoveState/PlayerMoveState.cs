
/*****************************************************************************************
* PlayerMoveState
*  Base class to define the eligible movement behavior of the player.
*  
*****************************************************************************************/

using UnityEngine;

public abstract class PlayerMoveState 
{
    //********************************************************************************
    // Enum of Player Move State
    //********************************************************************************

    public enum PLAYER_MOVE_STATE
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    //********************************************************************************
    // Member Variables
    //********************************************************************************

    public PLAYER_MOVE_STATE STATE;
    protected Vector2 dir;

    //********************************************************************************
    // Utility
    //********************************************************************************

    abstract public PLAYER_MOVE_STATE ChangeState();

    public void Move(Transform transform)
    {
        transform.Translate(dir);
    }
   
}

