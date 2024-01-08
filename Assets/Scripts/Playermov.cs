using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermov : MonoBehaviour
{

    private Rigidbody2D kropp;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField] private LayerMask jumpableground;

    private float dirx = 0;
    [SerializeField] private float movespeed = 7;
    [SerializeField] private float jumpforce = 15;

    private enum Movementstate { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpsound;

    // Start is called before the first frame update
    private void Start()
    {
        kropp = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded())
        {
            jumpsound.Play();
            kropp.velocity = new Vector2(kropp.velocity.x, jumpforce);
        }

        dirx = Input.GetAxisRaw("Horizontal");

        kropp.velocity = new Vector2(dirx * movespeed, kropp.velocity.y);

        UpdateAnim();
    }
    
    private void UpdateAnim()
    {
        Movementstate state;

        if (dirx > 0)
        {
            state = Movementstate.running;
            sprite.flipX = false;
        }
        else if (dirx < 0)
        {
            state = Movementstate.running;
            sprite.flipX = true;
        }
        else
        {
            state = Movementstate.idle;
        }

        if (kropp.velocity.y > 0.1)
        {
            state = Movementstate.jumping;
        }
        else if (kropp.velocity.y < -0.1)
        {
            state = Movementstate.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool grounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, jumpableground);
    }
}
