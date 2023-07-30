
/*****************************************************************************************
* PlayerMoveLeft
*  Determines eligible key inputs for movement. 
*  
*****************************************************************************************/

using UnityEngine;

public class PlayerMoveLeft : PlayerMoveState
{
    //********************************************************************************
    // Constructor
    //********************************************************************************

    public PlayerMoveLeft()
    {
        STATE = PLAYER_MOVE_STATE.LEFT;
        dir = -Vector2.right;
    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    override public PLAYER_MOVE_STATE ChangeState()
    {
        PLAYER_MOVE_STATE state = STATE;
        if (Input.GetKey(KeyCode.UpArrow))
            state = PLAYER_MOVE_STATE.UP;
        else if (Input.GetKey(KeyCode.DownArrow))
            state = PLAYER_MOVE_STATE.DOWN;

        return state;
    }

}

