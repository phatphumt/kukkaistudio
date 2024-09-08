using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeText;
    void OnEnable()
    {
        scoreText.text = $"Score: {PlayerPrefs.GetInt("score")}";
        float time = PlayerPrefs.GetFloat("time");
        timeText.text = $"Time: {System.Math.Floor(time / 60).ToString().PadLeft(2, '0')}:{System.Math.Floor(time % 60).ToString().PadLeft(2, '0')}";
    }
}
