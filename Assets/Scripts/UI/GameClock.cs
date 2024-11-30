using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI seasonText;
    [SerializeField] private TextMeshProUGUI yearText;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI hourText;

    private void OnEnable()
    {
        EventHandler.timeUpdateEvent += UpdateTime;
    }

    private void OnDisable()
    {
        EventHandler.timeUpdateEvent -= UpdateTime;
    }

    private void UpdateTime(GameTime gameTime)
    {
        seasonText.text = gameTime.Season.ToString();
        yearText.text = "Year " + gameTime.Year.ToString();
        dayText.text = gameTime.GetMonthName() + " " + gameTime.Day.ToString();

        int minutes = gameTime.Minute - (gameTime.Minute % 10);
        string clockText = gameTime.Hour.ToString("00") + ":" + minutes.ToString("00");
        hourText.text = clockText;
    }
}
