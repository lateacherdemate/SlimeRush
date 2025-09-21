using UnityEngine;

public class Dragonfruit : MonoBehaviour
{
    public UI ui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerState playerState = collision.GetComponent<PlayerState>();

            if (playerState != null)
            {
                playerState.EatAnimation();
                ui.dragonfruits++;
                Destroy(gameObject);
            }
        }
    }

}
