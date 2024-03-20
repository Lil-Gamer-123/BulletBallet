using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Rigidbody2D rb;
    private GameLogic gameLogic;
    private AudioSource sound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameLogic = FindAnyObjectByType<GameLogic>().GetComponent<GameLogic>();

        sound = GetComponent<AudioSource>();
        sound.Play();

        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 10f){
            Destroy(gameObject);

            gameLogic.DecScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){        
        Destroy(gameObject);
    }
}
