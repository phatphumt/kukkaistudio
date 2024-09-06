using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ProgessBar progessBarHP;
    public int score { get; private set; } = 0;
    public int hp { get; private set; } = 100;

    public void IncrementScore() 
    {
        score += 1;
    }

    public void UpdateHP(int newHP)
    {
        hp += newHP;
        progessBarHP.UpdateHPBar(hp);
    }
}
