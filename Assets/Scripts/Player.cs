using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] GameController gameController;

    private bool isOnCooldown = false;
    private Vector2 vt;

    // Update is called once per frame
    private void Update()
    {
        vt = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetMouseButton(0) && !isOnCooldown)
        {
            StartCoroutine(nameof(StartCooldown));
            GameObject bullet = Instantiate(bulletObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<BulletController>().bulletPoint = bulletSpawnPoint;
            Debug.Log(gameController.GetComponent<UIController>());
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
