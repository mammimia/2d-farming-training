using System.Collections;
using UnityEngine;

public class ItemNudge : MonoBehaviour
{
    private WaitForSeconds wait;
    private bool isNudging;

    private void Awake()
    {
        wait = new WaitForSeconds(0.04f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isNudging) return;

        bool isPlayerOnRight = gameObject.transform.position.x < other.gameObject.transform.position.x;
        StartCoroutine(NudgeItem(isPlayerOnRight ? 1 : -1));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isNudging) return;
        bool isPlayerOnRight = gameObject.transform.position.x < other.gameObject.transform.position.x;
        StartCoroutine(NudgeItem(isPlayerOnRight ? -1 : 1));
    }

    private IEnumerator NudgeItem(int isPlayerOnRight)
    {
        isNudging = true;

        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f * isPlayerOnRight);
            yield return wait;
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f * isPlayerOnRight);
            yield return wait;
        }

        gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f * isPlayerOnRight);
        yield return wait;

        isNudging = false;
    }
}
