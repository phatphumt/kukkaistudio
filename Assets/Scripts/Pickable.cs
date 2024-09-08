using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().UpdateHP(10);
            Destroy(gameObject);
        }
    }
}
