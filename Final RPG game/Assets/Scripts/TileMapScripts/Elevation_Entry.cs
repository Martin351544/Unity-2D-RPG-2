using UnityEngine;

public class Elevation_Entry : MonoBehaviour
{
    public Collider2D[] mountainColliders;
    public Collider2D[] Boundrycolliders;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled=false;
            }
            foreach (Collider2D boundry in Boundrycolliders)
            {
                boundry.enabled = true;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 51;
        }
    }
}
