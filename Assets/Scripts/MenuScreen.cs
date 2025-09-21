using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScreen : MonoBehaviour
{
    public Animator animator; 

    public void PlayGame()
    {

        Debug.Log("Button pressed, starting animation.");
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned.");
        }
        else
        {
        animator.SetTrigger("Pressed");
        }
            
        StartCoroutine(LoadSceneWithDelay());
    }

    private System.Collections.IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(0.2f);

            SceneManager.LoadScene("Game");


    }
 
}

