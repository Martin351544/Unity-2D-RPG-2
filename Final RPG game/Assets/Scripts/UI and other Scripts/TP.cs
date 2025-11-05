using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TP : MonoBehaviour
{

    string SceneToLoad;
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeScene();
    }
}