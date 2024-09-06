using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Debug.Log(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().score);
    }

    public void UpdateScoreText()
    {
        scoreText.text = gameController.score.ToString().PadLeft(3, '0');
    }
}
