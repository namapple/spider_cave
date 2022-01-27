using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            if (gameObject.name == "Air")
            {
                GameObject.Find("Game Play Controller").GetComponent<AirTimer>().air += 15f;
            }
            else
            {
                GameObject.Find("Game Play Controller").GetComponent<LevelTimer>().timer += 15f;
            }
            Destroy(gameObject);
        }
    }
}
