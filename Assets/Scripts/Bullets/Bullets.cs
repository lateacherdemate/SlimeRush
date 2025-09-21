using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 10f; 
    public float lifetime = 2f; 

    private float direction = 1f;

    
    public void SetDirection(float dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.position += Vector3.right * speed * direction * Time.deltaTime;
    }

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }
}
