using UnityEngine;

public class Mango : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerState playerState = collision.GetComponent<PlayerState>();

            if (playerState != null)
            {
                playerState.Eat();
                playerState.mangoEaten = true;
                Destroy(gameObject);
            }
        }
    }

}
