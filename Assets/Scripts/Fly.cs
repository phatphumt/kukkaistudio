using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class Fly : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public Transform bulletPoint;
    public UnityEvent bulletEvent;
    private Vector3 blp;
    private bool isOnCooldown;

    void Start() 
    {
        blp = bulletPoint.up;
    }

    void FixedUpdate()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(nameof(StartCooldown));
            rb.AddForce(blp.normalized * speed, ForceMode2D.Impulse);
        }
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(1f);
        isOnCooldown = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag("Enemy"))
        {
            bulletEvent.Invoke();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
