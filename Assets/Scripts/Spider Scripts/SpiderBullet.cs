using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }

        if (target.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
