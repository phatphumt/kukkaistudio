using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject pickable;
    [SerializeField] ProgessBar progessBarHP;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] AudioClip healingSound;
    [SerializeField] AudioSource audioSource;
    public int score { get; private set; } = 0;
    public int hp { get; private set; } = 100;
    public float elapsedTime;

    void Start()
    {
        progessBarHP.UpdateHPBar(hp);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void IncrementScore()
    {
        score += 1;
        audioSource.PlayOneShot(enemyDeathSound);
    }

    public void UpdateHP(int newHP)
    {
        if (newHP > 0)
            audioSource.PlayOneShot(healingSound);

        hp += newHP;
        progessBarHP.UpdateHPBar(hp);
        if (hp <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetFloat("time", elapsedTime);
    }
}
