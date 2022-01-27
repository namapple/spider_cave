using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerScript player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left")
        {
            player.SetMoveLeft(true);
        }
        else
        {
            player.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        player.StopMoving();
    }
}
