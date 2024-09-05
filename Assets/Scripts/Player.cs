using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform bulletSpawnPoint;

    private bool isOnCooldown = false;
    private Vector2 vt;
    public int hp { 
        get { return hp; }
        set { 
            hp = value; 
        }
    }

    // Update is called once per frame
    private void Update()
    {
        vt = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetMouseButton(0) && !isOnCooldown)
        {
            StartCoroutine(nameof(StartCooldown));
            GameObject bullet = Instantiate(bulletObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Fly>().bulletPoint = bulletSpawnPoint;
            bullet.GetComponent<Fly>().bulletEvent.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().IncrementScore);
            bullet.GetComponent<Fly>().bulletEvent.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().UpdateScoreText);
            Debug.Log(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>());
        }
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(0.5f);
        isOnCooldown = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = vt * 10;
    }
}
