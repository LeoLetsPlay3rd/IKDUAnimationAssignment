using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int stars = 0; //This is the start count of the stars.

    [SerializeField] private Text starsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star")) //References to gameobjects with the tag created for the collectable item (star) attached to it.
        {
            Destroy(collision.gameObject); //The gameobject will disapear.
            stars++; //This will add +1 star to the star-count.
            starsText.text = "Stars: " + stars; //This will let us know the star count works by showing it in the console.
        }
    }
}
