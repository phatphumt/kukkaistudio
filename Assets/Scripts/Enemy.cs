using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject target;


    public UnityEvent bulletEvent;
    public int hp = 20;

    private void Awake()
    {
        bulletEvent.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().IncrementScore);
        bulletEvent.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().UpdateScoreText);
    }

    private void Update()
    {
        if (hp <= 0)
        {
            bulletEvent.Invoke();
            Destroy(gameObject);
        }
    }

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
