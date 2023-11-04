using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadOverlay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ScreenUtils.FadeScreen(GetComponent<Image>(), 0.5f, true));
    }
}
