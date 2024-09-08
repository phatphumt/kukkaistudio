using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] int sceneID = 1;
    void Start()
    {
        button.onClick.AddListener(ChangeScenes1);
    }

    void ChangeScenes1()
    {
        SceneManager.LoadScene(sceneID);
    }
}
