using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject bulletObject;
    private Vector2 vt;

    // Update is called once per frame
    private void Update()
    {
        vt = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletObject, );
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = vt * 10;
    }
}
