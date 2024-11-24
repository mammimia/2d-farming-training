using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemFader : MonoBehaviour
{
    private SpriteRenderer theSR;

    private void Awake()
    {
        theSR = gameObject.GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        float currentAlpha = theSR.color.a;
        float distance = currentAlpha - Settings.fadeAlpha;
        while (currentAlpha - Settings.fadeAlpha > 0.01f)
        {
            currentAlpha -= distance / Settings.fadeOutDuration * Time.deltaTime;
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, currentAlpha);
            yield return null;
        }

        theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, Settings.fadeAlpha);
    }

    private IEnumerator FadeInRoutine()
    {
        float currentAlpha = theSR.color.a;
        float distance = 1f - currentAlpha;

        while (1f - currentAlpha > 0.01f)
        {
            currentAlpha += distance / Settings.fadeInDuration * Time.deltaTime;
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, currentAlpha);
            yield return null;
        }

        theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1);
    }
}
