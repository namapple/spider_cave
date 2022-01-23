using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumpForce = 700f;
    public float maxVelocity = 4f;
    private bool grounded;
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
        // nhân vật di chuyển theo chiều ngang
        float forceX = 0f;
        // nhân vật nhảy lên
        float forceY = 0f;
        // lấy vận tốc hiện tại của nhân vật
        float curVelocity = Mathf.Abs(myBody.velocity.x);
        // biến đổi các phím A/<- (move left) hoặc D/-> (move right)
        // thành -1 0 1, tương ứng left - not pressed - right 
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if (curVelocity < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }
            //đổi hướng mặt nhân vật khi di chuyển
            // x = 1 -> facing right, x = -1 -> facing left
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            // thay đổi hoạt cảnh khi di chuyển
            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (curVelocity < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            //đổi hướng mặt nhân vật khi di chuyển
            // x = 1 -> facing right, x = 1 -> facing left
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }

    //nhân vật đứng trên ground -> true, true mới nhảy được
    //làm vậy để tránh nhảy trong không trung
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
