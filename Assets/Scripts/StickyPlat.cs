using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlat : MonoBehaviour
{
    private Transform ogparent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ogparent = collision.gameObject.transform.parent;

            collision.gameObject.transform.SetParent(transform);
        }
    }

    private async void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(ogparent);
        }
    }

}
