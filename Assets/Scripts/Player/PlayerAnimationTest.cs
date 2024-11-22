using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float inputX;
    public float inputY;
    public MovementState movementState;
    public ToolEffect toolEffect;
    public ToolAction toolAction;
    public Direction direction;

    private void Update()
    {
        EventHandler.CallMovementEvent(
            inputX, inputY,
            movementState,
            toolEffect,
            toolAction,
            direction
        );
    }
}
