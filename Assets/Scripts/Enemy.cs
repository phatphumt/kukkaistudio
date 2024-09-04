using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject target;


    private void FixedUpdate()
    {
        Vector2 dir = target.transform.position - transform.position;
        rb.velocity = dir.normalized * 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("test123");
        }
    }
}
