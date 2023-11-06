using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadOverlay : MonoBehaviour
{
    [SerializeField] private string nextScene;

    void Start()
    {
        StartCoroutine(LoadIn());
    }

    public IEnumerator LoadIn() {
        yield return ScreenUtils.FadeScreen(GetComponent<Image>(), 0.5f, true);
    }

    public IEnumerator LoadOut() {
        yield return ScreenUtils.FadeScreen(GetComponent<Image>(), 0.5f, false);
        SceneManager.LoadScene(nextScene);
    }
}
