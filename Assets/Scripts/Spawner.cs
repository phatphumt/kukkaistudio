using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    bool isOnCooldown = false;

    void Update()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(nameof(StartCooldown));
            GameObject obj = Instantiate(enemy, transform.position, Quaternion.identity);
            obj.GetComponent<Enemy>().bulletEvent.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().IncrementScore);
            obj.GetComponent<Enemy>().bulletEvent.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().UpdateScoreText);
            obj.GetComponent<Enemy>().target = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().player;
        }
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(5f);
        isOnCooldown = false;
    }
}
