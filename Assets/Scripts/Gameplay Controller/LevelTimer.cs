using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public float timer = 10f;
    private float timerBurn = 1f;

    private void Awake()
    {
        GetReference();
    }
    private void Update()
    {
        if (!player) return;
        if (timer > 0)
        {
            timer -= timerBurn * Time.deltaTime;
            slider.value = timer;
        }
        else

        {
            GetComponent<GamePlayController>().PlayerDied();
            Destroy(player);
        }
    }

    void GetReference()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }
}
