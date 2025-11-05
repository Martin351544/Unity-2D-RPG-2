using UnityEngine;
using UnityEngine.SceneManagement;

public class TpButton : MonoBehaviour
{
    public string SceneToLoad = "RPG Spawn";

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
