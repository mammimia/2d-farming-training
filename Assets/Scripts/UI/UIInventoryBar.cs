using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    private RectTransform rectTransform;
    private bool _isInventoryBarOnTop = true;

    private bool isInventoryBarOnTop
    {
        get => _isInventoryBarOnTop;
        set => _isInventoryBarOnTop = value;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        switchInventoryBarPosition();
    }

    private void switchInventoryBarPosition()
    {
        Vector3 playerViewportPosition = Player.Instance.getPlayerViewportPosition();

        if (playerViewportPosition.y > 0.3f && !isInventoryBarOnTop)
        {
            rectTransform.anchorMin = new Vector2(0.5f, 0);
            rectTransform.anchorMax = new Vector2(0.5f, 0);
            rectTransform.pivot = new Vector2(0.5f, 0);
            rectTransform.anchoredPosition = new Vector2(0, 2.5f);

            isInventoryBarOnTop = true;
        }
        else if (playerViewportPosition.y <= 0.3f && isInventoryBarOnTop)
        {
            rectTransform.anchorMin = new Vector2(0.5f, 1);
            rectTransform.anchorMax = new Vector2(0.5f, 1);
            rectTransform.pivot = new Vector2(0.5f, 1);
            rectTransform.anchoredPosition = new Vector2(0, -2.5f);

            isInventoryBarOnTop = false;
        }
    }
}
