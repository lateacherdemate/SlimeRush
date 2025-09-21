using UnityEngine;

public class Static_Bullets : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.NumberOfbullets++;
                Destroy(gameObject);
            }
        }
    }
}
