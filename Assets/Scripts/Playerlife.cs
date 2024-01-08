using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    private Rigidbody2D kropp;
    private Animator anim;

    [SerializeField] private AudioSource deathsound;

    void Start()
    {
        kropp = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Die();
        }
    }
    private void Die()
    {
        deathsound.Play();
        kropp.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");

    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
