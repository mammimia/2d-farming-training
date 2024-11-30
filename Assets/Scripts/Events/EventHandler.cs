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

    // Time Events
    public static event Action<GameTime> timeUpdateEvent;

    public static void CallTimeUpdateEvent(GameTime gameTime)
    {
        if (timeUpdateEvent != null)
        {
            timeUpdateEvent(gameTime);
        }
    }

    public static event Action<GameTime> hourUpdateEvent;
    public static void CallHourUpdateEvent(GameTime gameTime)
    {
        if (hourUpdateEvent != null)
        {
            hourUpdateEvent(gameTime);
        }
    }

    public static event Action<GameTime> dayUpdateEvent;
    public static void CallDayUpdateEvent(GameTime gameTime)
    {
        if (dayUpdateEvent != null)
        {
            dayUpdateEvent(gameTime);
        }
    }

    public static event Action<GameTime> yearUpdateEvent;
    public static void CallYearUpdateEvent(GameTime gameTime)
    {
        if (yearUpdateEvent != null)
        {
            yearUpdateEvent(gameTime);
        }
    }

    public static event Action<Season> seasonUpdateEvent;
    public static void CallSeasonUpdateEvent(Season season)
    {
        if (seasonUpdateEvent != null)
        {
            seasonUpdateEvent(season);
        }
    }


}