using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finsih : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;

    private bool levelcompleted = false;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "Player" && !levelcompleted)
        {
            finishSound.Play();
            levelcompleted = true;
            Invoke("lvlcomplete", 2f);
        }
    }

    private void lvlcomplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
