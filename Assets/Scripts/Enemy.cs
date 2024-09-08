using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform headPoint;
    public GameObject target;


    public UnityEvent bulletEvent;
    public int hp = 20;

    private bool onAttackCd = false;

    private void Awake()
    {
        bulletEvent.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().IncrementScore);
        bulletEvent.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().UpdateScoreText);
    }

    private void Update()
    {
        if (hp <= 0) // enemi dia
        {
            bulletEvent.Invoke();
            int random = (int)Random.Range(1f, 5f);
            Debug.Log(random);
            if (random == 1)
            {
                Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().pickable, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = target.transform.position - transform.position;
        transform.up = dir;
        rb.velocity = dir.normalized * 2;
        Collider2D bangbang = Physics2D.OverlapCircle(headPoint.position, 1f);
        if (bangbang.gameObject.CompareTag("Player") && !onAttackCd)
        {
            StartCoroutine(nameof(StartCooldown));
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().UpdateHP(-10);
        }
    }

    private IEnumerator StartCooldown()
    {
        onAttackCd = true;
        yield return new WaitForSeconds(2f);
        onAttackCd = false;
    }
}
