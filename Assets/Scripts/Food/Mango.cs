using UnityEngine;

public class Mango : MonoBehaviour
{
    public UI ui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerState playerState = collision.GetComponent<PlayerState>();

            if (playerState != null)
            {
                playerState.EatMango();
                
                playerState.EatAnimation();
                Destroy(gameObject);
                ui.mangos++;
            }
        }
    }

}
