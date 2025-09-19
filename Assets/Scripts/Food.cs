using UnityEngine;

public class Food : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState playerState = collision.gameObject.GetComponent<PlayerState>();

            if (playerState != null)
            {
                playerState.Eat();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerState playerState = collision.GetComponent<PlayerState>();

            if (playerState != null)
            {
                playerState.Eat();
                Destroy(gameObject);
            }
        }
    }

}
