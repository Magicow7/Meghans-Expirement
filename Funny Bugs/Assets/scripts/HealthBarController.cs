using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    [SerializeField] private GameObject mainBar;
    [SerializeField] private GameObject backBar;
    [SerializeField] private CharacterStatusController health;
    private float lastHealth;

    [SerializeField] private float resetTime;
    [SerializeField] private float lastUpdate; 

    private bool coroutineLock = false;
    Slider mainSlider, backSlider;
    // Start is called before the first frame update
    void Awake()
    {
        lastHealth = health.Health;
        mainSlider = mainBar.GetComponent<Slider>();
        backSlider = backBar.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastHealth / health.MaxHealth - (float)health.Health / health.MaxHealth >= 0.001) {
            lastUpdate = resetTime;
            StartCoroutine(LoseHealth());
        }
        mainSlider.value = (float)health.Health / health.MaxHealth;
        lastUpdate -= Time.deltaTime;
        lastHealth = health.Health;
    }

    private IEnumerator LoseHealth() {
        if (!coroutineLock) {
            coroutineLock = true;
            yield return new WaitUntil(() => lastUpdate <= 0);
            while (backSlider.value > mainSlider.value) {
                backSlider.value -= 0.001f;
                yield return new WaitForSeconds(0.001f);
            }
            coroutineLock = false;
        }
    }
}
