using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUtils
{
    public static IEnumerator FadeScreen(Image image, float seconds, bool reversed) {
        Color color = image.color;

        if (reversed)
            color.a = 1.0f;
        else
            color.a = 0.0f;

        for (int i = 0; i < 100; i++) {
            yield return new WaitForSeconds(seconds / 100);
            if (reversed)
                color.a -= 1.0f / 100;
            else 
                color.a += 1.0f / 100;
            image.color = color;
        }
    }
}