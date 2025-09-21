using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int lives = 3;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
           lives--;
           Destroy(collision.gameObject);
            if(lives>0){
              HarmedAnimation();
            }
            else if(lives <= 0)
            {
              DieAnimation();
            }
        }
    }

    public void DieAnimation()
    {
       Debug.Log("Enemy Dying activated");

       if (animator != null)
       {
          animator.SetTrigger("Die");
       }

        StartCoroutine(StopDieAnimation());
    }

    private System.Collections.IEnumerator StopDieAnimation()
    {

        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
       
    }

    public void HarmedAnimation()
    {
        Debug.Log("Enemy harmed activated");

        if (animator != null)
        {
            animator.SetTrigger("Harmed");
        }

        StartCoroutine(StopHarmedAnimation());
    }

    private System.Collections.IEnumerator StopHarmedAnimation()
    {

        yield return new WaitForSeconds(0.2f);
        if (animator != null)
        {
            animator.ResetTrigger("Harmed");
        }
    }

}
