using UnityEngine;

public class Practice : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumpForce = 700f;
    public float maxVelocity = 4f;
    private bool isGrounded;
    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerWalkKeyBoard();
    }
    private void PlayerWalkKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                if (isGrounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }
            Vector3 tempScale = transform.localScale;
            tempScale.x = 1f;
            transform.localScale = tempScale;
            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                if (isGrounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 tempScale = transform.localScale;
            tempScale.x = -1f;
            transform.localScale = tempScale;
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                isGrounded = false;
                forceY = jumpForce;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
