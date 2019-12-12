using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    public bool upSideDown = false;   
    public Rigidbody2D rb;
    public AudioSource Audio;
   
    public AudioClip walkingAudio;
    private float AudioPitch = 0.3f;



    public bool isTouching = true;
    private float moveX;
  
    public int powerSource = 2;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per 
    void Update()
    {
        PlayerMove();
        }

    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");


        if (moveX < 0.0f)

        {

            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
 
            Jump();
            
            


            if (upSideDown == false)
            {
                FlipPlayer();
            }
            else if (upSideDown == true)
            {
                FlipPlayer();
            }
        }

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


        //Inverting gravity
        void Jump()
        {
            
            gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
           

        }

        //Animations
        if (moveX != 0)
        {
            
            if (GetComponent<Rigidbody2D>().velocity.y != 0)
            {
                GetComponent<Animator>().SetBool("IsRunning", false);
                isTouching = false;

            }

            if (GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                Audio.pitch = AudioPitch;
                GetComponent<Animator>().SetBool("IsRunning", true);
                Audio.clip = walkingAudio;
                
                Audio.Play();
            }
            
        }

        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
            
        }

        //flips the player upsidedown

        void FlipPlayer()
        {
            upSideDown = !upSideDown;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.y *= -1;
            transform.localScale = localScale;
        }


        
    }


}







