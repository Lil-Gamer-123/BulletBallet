using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject nextBall;
    private GameLogic gameLogic;

    int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameLogic = FindAnyObjectByType<GameLogic>().GetComponent<GameLogic>();
        
        rb.velocityX = speed;
        rb.velocityY = 2f;
    }

    void Update()
    {
        if(transform.position.y > 7f){
            rb.velocityY = 0;
        }

        if(rb.velocityX > 0 && speed > 0){
            rb.velocityX = speed;
        }else if(rb.velocityX > 0 && speed > 0){
            rb.velocityX = -speed;
        }else if(rb.velocityX > 0 && speed < 0){
            rb.velocityX = -speed;
        }else if(rb.velocityX < 0 && speed < 0){
            rb.velocityX = speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground"){
            jumpCount += 1;
            if(jumpCount == 3){
                rb.velocityY = -rb.velocityY * 1.05f;
                jumpCount = 0;

                if(rb.velocityY < 10f){
                    rb.velocityY = 25f;
                }
            }else{
                rb.velocityY = -rb.velocityY * 1.02f;
            }
        }else if(collision.gameObject.tag == "SideWall"){
            rb.velocityX = -rb.velocityX;
        }else if(collision.gameObject.tag == "Bullet"){
            gameLogic.AddScore();
            if(nextBall) SummonNextBalls(gameObject);

            Destroy(gameObject);
            gameLogic.BallRemove();
        }
    }

    private void SummonNextBalls(GameObject gameObject){
        SummonBall(gameObject);
        SummonBall(gameObject);
    }

    private void SummonBall(GameObject gameObject){
        Instantiate(nextBall, gameObject.transform.position, gameObject.transform.rotation);
        nextBall.GetComponent<Ball>().speed = - nextBall.GetComponent<Ball>().speed;

        gameLogic.BallAdd();
    }

}
