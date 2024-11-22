using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float inputX;
    public float inputY;
    public MovementState movementState;
    public ToolEffect toolEffect;
    public ToolAction toolAction;
    public Direction toolDirection;
    public Direction idleDirection;

    private void Update()
    {
        EventHandler.CallMovementEvent(
            inputX, inputY,
            movementState,
            toolEffect,
            toolAction,
            toolDirection,
            idleDirection
        );
    }
}
