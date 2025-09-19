using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public float fadeTime = 0.5f;
    public Animator fadeAnim;
    public Vector2 newPlayerPosition;
    private Transform player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            StartCoroutine(FadeAndLoad());
        }
    }

    IEnumerator FadeAndLoad()
    {
        fadeAnim.SetTrigger("FadeAnimation"); // make sure you have a trigger in Animator
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(sceneToLoad);
    }
}
