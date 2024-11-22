public delegate void MovementDelegate(float inputX, float inputY,
    MovementState movementState,
    ToolEffect toolEffect,
    ToolAction toolAction,
    Direction toolDirection,
    Direction idleDirection);

public static class EventHandler
{
    public static event MovementDelegate movementEvent;

    public static void CallMovementEvent(
        float inputX, float inputY,
        MovementState movementState,
        ToolEffect toolEffect,
        ToolAction toolAction,
        Direction toolDirection,
        Direction idleDirection)
    {
        if (movementEvent != null)
        {
            movementEvent(inputX, inputY, movementState, toolEffect, toolAction, toolDirection, idleDirection);
        }
    }
}