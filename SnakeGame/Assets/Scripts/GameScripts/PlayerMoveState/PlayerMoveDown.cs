
/*****************************************************************************************
* PlayerMoveDown
*  Determines eligible key inputs for movement. 
*  
*****************************************************************************************/

using UnityEngine;

public class PlayerMoveDown : PlayerMoveState
{
    //********************************************************************************
    // Constructor
    //********************************************************************************

    public PlayerMoveDown()
    {
        STATE = PLAYER_MOVE_STATE.DOWN;
        dir = -Vector2.up;
    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    override public PLAYER_MOVE_STATE ChangeState()
    {
        PLAYER_MOVE_STATE state = STATE;
        if (Input.GetKey(KeyCode.RightArrow))
            state = PLAYER_MOVE_STATE.RIGHT;
        else if (Input.GetKey(KeyCode.LeftArrow))
            state = PLAYER_MOVE_STATE.LEFT;

        return state;
    }
}

