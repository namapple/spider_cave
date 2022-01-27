using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    void Start()
    {
        if (Door.instance != null)
        {
            Door.instance.collectablesCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (Door.instance != null)
            {
                Door.instance.DecrementCollectables();
            }
        }
    }
    void Update()
    {

    }
}
