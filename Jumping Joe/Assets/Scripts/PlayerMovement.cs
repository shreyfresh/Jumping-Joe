using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //movement variables
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rigidBody;
    private int extraJumps;
    public int extraJumpValue;

    //boolean for flipping the character
    private bool isFacingRight = true;
    
    //variables for checking if player is grounded
    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator animator;

    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        extraJumps = extraJumpValue;
    }
    void Update()
    {
        //Getting horizontal input
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput < 0 && isFacingRight){
            Flip();
        }
        else if (moveInput > 0 && !isFacingRight){
            Flip();
        }

        if(moveInput == 0){
            animator.SetBool("IsRunning", false);
        }else{
            animator.SetBool("IsRunning", true);
        } 


        if(isGrounded){
            extraJumps = extraJumpValue;
        }
        //Getting spacebar input
        if (Input.GetButtonDown("Jump") && extraJumps > 0){
            Jump(true);
        }else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded){
            Jump(false);
        }
        
    }
    /*
    All movement for the player goes into Fixed Update because there is a fixed amount of frames that allows players from
    any computer to perform the same. Jumping does not need to be here
    */
    void FixedUpdate() {
        Grounded();
        Walk(moveInput);
    }
	
    //walk function
    void Walk(float moveInput){
		Vector2 dir = new Vector2(moveInput * speed, rigidBody.velocity.y);
		rigidBody.velocity = dir;
	}

	//flip character function
	void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
	}

    //jump function
	void Jump(bool decreaseJumps){
        FindObjectOfType<MusicPlayer>().Play("PlayerJump");
		rigidBody.velocity = Vector2.up * jumpForce ;
        if(decreaseJumps){
            extraJumps--;   
        }
	}

    //check if the player is grounded
    void Grounded(){
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);
    }

    public void Win(){
        if(SceneManager.GetActiveScene().buildIndex < 6){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }else{
            SceneManager.LoadScene("Menu");
        }
    }
    public void Lose(){
        FindObjectOfType<MusicPlayer>().Play("PlayerDeath");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
