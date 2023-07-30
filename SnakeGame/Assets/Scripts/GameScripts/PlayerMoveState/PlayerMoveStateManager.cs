
/*****************************************************************************************
* PlayerMoveStateManager
*  Manager for all possible player move states. Updates the state based on the condition
*  
*****************************************************************************************/

using UnityEngine;

public class PlayerMoveStateManager
{
    //********************************************************************************
    // Member Variables
    //********************************************************************************

    private PlayerMoveState currentState;
    private PlayerMoveRight rightMoveState;
    private PlayerMoveLeft  leftMoveState;
    private PlayerMoveUp    upMoveState;
    private PlayerMoveDown  downMoveState;

    //********************************************************************************
    // Constructor
    //********************************************************************************

    public PlayerMoveStateManager()
    {
        rightMoveState = new PlayerMoveRight();
        leftMoveState = new PlayerMoveLeft();
        upMoveState = new PlayerMoveUp();
        downMoveState = new PlayerMoveDown();
        currentState = rightMoveState;

    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    public void Move(Transform transform)
    {
        currentState.Move(transform);
    }

    public void CheckForStateUpdate()
    {
        PlayerMoveState.PLAYER_MOVE_STATE state = currentState.ChangeState();
        if ( state != currentState.STATE)
        {
            switch (state)
            {
                case PlayerMoveState.PLAYER_MOVE_STATE.UP:
                    currentState = upMoveState;
                    break;
                case PlayerMoveState.PLAYER_MOVE_STATE.DOWN:
                    currentState = downMoveState;
                    break;
                case PlayerMoveState.PLAYER_MOVE_STATE.RIGHT:
                    currentState = rightMoveState;
                    break;
                case PlayerMoveState.PLAYER_MOVE_STATE.LEFT:
                    currentState = leftMoveState;
                    break;
                default:
                    break;
            }

        }

    }

}

