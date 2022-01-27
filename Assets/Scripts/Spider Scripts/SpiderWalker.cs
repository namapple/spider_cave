using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPos;
    private bool collision;
    public float speed = 1f;
    private Rigidbody2D myBody;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }
    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }

    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(startPos.position, endPos.position, Color.green);
        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f)
            {
                temp.x = -1f;
            }
            else
            {
                temp.x = 1f;
            }
            transform.localScale = temp;
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            GameObject.Find("Game Play Controller").GetComponent<GamePlayController>().PlayerDied();
            Destroy(target.gameObject);
        }
    }
}
