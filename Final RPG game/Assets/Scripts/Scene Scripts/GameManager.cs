using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("persistant Objects")]
    public GameObject [] persistantObjects;


    void Awake()
    {
        if (Instance != null)
        {
            CleanUpAndDestroy();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistantObjects();
        }
    }

    private void MarkPersistantObjects()
    {
        foreach (GameObject obj in persistantObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistantObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
