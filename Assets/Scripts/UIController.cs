using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeText;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        timeText.text = $"{System.Math.Floor(gameController.elapsedTime / 60).ToString().PadLeft(2, '0')}:{System.Math.Floor(gameController.elapsedTime % 60).ToString().PadLeft(2, '0')}";
    }

    public void UpdateScoreText()
    {
        scoreText.text = gameController.score.ToString().PadLeft(3, '0');
    }
}
