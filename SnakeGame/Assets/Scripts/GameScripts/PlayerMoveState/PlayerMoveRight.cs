
/*****************************************************************************************
* PlayerMoveRight
*  Determines eligible key inputs for movement. 
*  
*****************************************************************************************/

using UnityEngine;

public class PlayerMoveRight : PlayerMoveState
{
    //********************************************************************************
    // Constructor
    //********************************************************************************

    public PlayerMoveRight()
    {
        STATE = PLAYER_MOVE_STATE.RIGHT;
        dir = Vector2.right;
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

