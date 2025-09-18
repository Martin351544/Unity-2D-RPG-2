using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject dialougeCanvas;
    [SerializeField]
    private TMP_Text speakerText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private Image portraitImage;

    
    [SerializeField]
    private string[] speaker;

    [SerializeField]
    [TextArea]
    private string [] dialogueWords;

    [SerializeField]
    private Sprite [] portrait;
    

    private bool dialogueActivated;
    private int step;
 
    void Update()
    {
        if (Input.GetButtonDown("Interact") && dialogueActivated == true)
        {

            if (step >= dialogueWords.Length)
            {
                dialougeCanvas.SetActive(false);
                step = 0;
            }
            else
            {
                dialougeCanvas.SetActive(true);
                speakerText.text = speaker[0];
                dialogueText.text = dialogueWords[step];
                portraitImage.sprite = portrait[0];
                step += 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogueActivated = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        dialogueActivated = false;
        dialougeCanvas.SetActive(false);
    }
}
