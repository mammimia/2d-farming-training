using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMonoBehavior<TimeManager>
{
    private GameTime currentTime = new GameTime(Season.Spring, 1, 1, 6, 0, 0);
    private bool isPaused = false;
    private float gameTick = 0f;

    private void Update()
    {
        if (!isPaused)
        {
            gameTick += Time.deltaTime;

            if (gameTick >= Settings.secondsPerGameSecond)
            {
                gameTick -= Settings.secondsPerGameSecond;
                currentTime.IncrementTime();
            }
        }
    }
}
