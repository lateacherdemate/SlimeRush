using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject upDoor;
    public GameObject downDoor;
    private Animator upDoorAnimator;
    private Animator downDoorAnimator;
    private Animator animator;

    private bool activated = false;

    void Start()
    {
        upDoorAnimator = upDoor.GetComponent<Animator>();
        downDoorAnimator = downDoor.GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (activated) return;
            upDoorAnimator.SetTrigger("Open");
            downDoorAnimator.SetTrigger("Open");
            upDoor.GetComponent<Collider2D>().enabled = false;
            downDoor.GetComponent<Collider2D>().enabled = false;
            animator.SetTrigger("Activated");

        }
    }

}
