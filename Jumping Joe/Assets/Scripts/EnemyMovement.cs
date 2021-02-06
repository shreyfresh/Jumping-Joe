using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speedMin;
    public float speedMax;
    private float speed;
    private Rigidbody2D rigidBody;
    public float timeToDespawn;
    
    public Transform circlePosition;
    public LayerMask whatIsGround;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        speed = Random.Range(speedMin, speedMax);
        if(Random.value >= 0.5){
            Flip();
        }
    }
    
    void Update(){
        if(Physics2D.OverlapCircle(circlePosition.position, 0.1f, whatIsGround)){
            Flip();
        }
        
        if(this.gameObject.transform.position.y <= -11f){
            timeToDespawn -= Time.deltaTime;
            if(timeToDespawn <= 0f){
                Destroy(gameObject);
            }
        }
    }
   
    void FixedUpdate() 
    {
        Vector2 dir = new Vector2(-speed, rigidBody.velocity.y);
		rigidBody.velocity = dir;
    }
    
    void Flip(){
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        speed = -speed;
	}
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerMovement>().Lose();
        }else if(other.gameObject.tag == "Enemy"){
            Flip();
        }
    }

    
    
    
}
