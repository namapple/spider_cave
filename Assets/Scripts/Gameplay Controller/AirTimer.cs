using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public float air = 10f;
    private float airBurn = 1f;

    private void Awake()
    {
        GetReference();
    }
    private void Update()
    {
        if (!player) return;
        if (air > 0)
        {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
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
        slider = GameObject.Find("Air Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;
    }
}
