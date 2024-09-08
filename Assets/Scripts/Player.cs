using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] GameController gameController;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioSource audioSource;

    private bool isOnCooldown = false;
    private Vector2 vt;

    private void Update()
    {
        vt = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetMouseButton(0) && !isOnCooldown)
        {
            StartCoroutine(nameof(StartCooldown));
            audioSource.PlayOneShot(shootingSound);
            GameObject bullet = Instantiate(bulletObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<BulletController>().bulletPoint = bulletSpawnPoint;
        }
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(.2f);
        isOnCooldown = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = vt * 10;
    }
}
