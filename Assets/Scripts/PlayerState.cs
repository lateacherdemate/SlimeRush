using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;

    private bool isDead = false;
    private bool isEating = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    //Animacion de comer
    public void Eat()
    {
        if (!isEating)
        {
            isEating = true;
            Debug.Log("Eat activado");

            
                playerMovement.moveSpeed *= 1.8f;
                if(playerMovement.jumpForce < 20)
                {
               playerMovement.jumpForce += 3.5f;
                }
            


            if (animator != null)
            {
                animator.SetTrigger("Eat");
            }

            StartCoroutine(StopEatAnimation());
        }
    }

    private System.Collections.IEnumerator StopEatAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        animator.ResetTrigger("Eat");
        isEating = false;
    }


    // Animacion de muerte
    public void Die()
    {
        if (!isDead)
        {
            isDead = true;

            if (animator != null)
            {
                animator.SetTrigger("Die");
            }

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }

            StartCoroutine(RestartScene());
        }
    }

    private System.Collections.IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
