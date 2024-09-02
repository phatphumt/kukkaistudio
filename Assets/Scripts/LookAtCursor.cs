using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 vt = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = new(vt.x - transform.position.x, vt.y - transform.position.y);

        transform.up = dir;
    }
}
