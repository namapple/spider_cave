using UnityEngine;
using System.Collections;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        StartCoroutine(Attack());
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            GameObject.Find("Game Play Controller").GetComponent<GamePlayController>().PlayerDied();
            Destroy(target.gameObject);
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
}
