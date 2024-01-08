using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int banana = 0;

    [SerializeField] private Text bananatext;

    [SerializeField] private AudioSource collectionsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            collectionsound.Play();

            Destroy(collision.gameObject);
            banana++;
            bananatext.text = "Bananas: "+ banana;
        }
    }
}
