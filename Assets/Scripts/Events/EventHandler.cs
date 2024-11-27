using System;
using System.Collections.Generic;

public delegate void MovementDelegate(float inputX, float inputY,
    MovementState movementState,
    ToolEffect toolEffect,
    ToolAction toolAction,
    Direction direction
);

public static class EventHandler
{
    public static event MovementDelegate movementEvent;

    public static void CallMovementEvent(
        float inputX, float inputY,
        MovementState movementState,
        ToolEffect toolEffect,
        ToolAction toolAction,
        Direction direction)
    {
        if (movementEvent != null)
        {
            movementEvent(inputX, inputY, movementState, toolEffect, toolAction, direction);
        }
    }

    public static event Action<List<InventoryItem>> inventoryUpdateEvent;

    public static void CallInventoryUpdateEvent()
    {
        if (inventoryUpdateEvent != null)
        {
            inventoryUpdateEvent(InventoryManager.Instance.GetInventoryList());
        }
    }
}