using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;

    public LayerMask ground;
    public LayerMask deathGround;

    private Rigidbody2D rigid;
    private Collider2D playerCollider;
    private Animator animator;

    public AudioSource deathSound;
    public AudioSource jumpSound;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultipier;

    public GameManager gameManager;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        mileStoneCount = mileStone;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);

        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                jumpSound.Play();
                rigid.velocity = new Vector2(rigid.velocity.x, jump);
            }
        }
        
        animator.SetBool("Grounded", grounded);

        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed = speed * speedMultipier;
            mileStone += mileStone * speedMultipier;

            Debug.Log("M" + mileStone + "." + "MC" + mileStoneCount + "." + "MS" + speed);
        }

        bool dead = Physics2D.IsTouchingLayers(playerCollider, deathGround);

        if (dead)
        {
            GameOver();
        }


    }
    
    void GameOver()
    {
        gameManager.GameOver();
    }
}
