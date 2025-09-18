using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour

{
    public string sceneToLoad;
    public float fadeTime = .5f;
    public Animator fadeAnim;
    public Vector2 newPlayerPosition;
    private Transform player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        fadeAnim.SetBool("isIdle" , false);
        if (collision.gameObject.tag == "Player")
        {
            player = collision.transform;
            fadeAnim.Play("FadeAnimation");
            StartCoroutine(DelayFade());
            fadeAnim.SetBool("isIdle" , true);
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(fadeTime);
        player.position = newPlayerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }
}
