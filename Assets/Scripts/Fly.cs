using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        rb.AddForce(Vector2.up * speed);
    }
}
