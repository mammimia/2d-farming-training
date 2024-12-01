using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : SingletonMonoBehavior<SceneController>
{
    private bool isFading;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private Image fadeImage;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    public SceneName startingScene;

    private IEnumerator Start()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 1f);
        fadeCanvasGroup.alpha = 1.0f;

        yield return StartCoroutine(LoadScene(startingScene.ToString()));
        EventHandler.CallAfterSceneLoadEvent();

        StartCoroutine(Fade(0.0f));
    }

    public void FadeAndLoadScene(string sceneName, Vector3 spawnPoint)
    {
        if (!isFading)
        {
            StartCoroutine(FadeAndSwitchScenes(sceneName, spawnPoint));
        }
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName, Vector3 spawnPoint)
    {
        EventHandler.CallSceneFadeOutEvent();

        yield return StartCoroutine(Fade(1.0f));

        Player.Instance.gameObject.transform.position = spawnPoint;

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        yield return StartCoroutine(LoadScene(sceneName));

        EventHandler.CallAfterSceneLoadEvent();

        yield return StartCoroutine(Fade(0.0f));

        EventHandler.CallSceneFadeInEvent();
    }

    private IEnumerator Fade(float finalAlpha)
    {
        isFading = true;
        fadeCanvasGroup.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(fadeCanvasGroup.alpha - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, finalAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        isFading = false;
        fadeCanvasGroup.blocksRaycasts = false;
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}
