using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartHandler : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Image fadeoutOverlay;
    void Update()
    {
        if (Input.anyKey)
            StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() {
        yield return ScreenUtils.FadeScreen(fadeoutOverlay, 0.15f, false);
        yield return ScreenUtils.FadeScreen(fadeoutOverlay, 0.15f, true);
        yield return ScreenUtils.FadeScreen(fadeoutOverlay, 0.10f, false);
        yield return ScreenUtils.FadeScreen(fadeoutOverlay, 0.10f, true);
        yield return ScreenUtils.FadeScreen(fadeoutOverlay, 0.05f, false);
        SceneManager.LoadScene(sceneName);
    }
}
