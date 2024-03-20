using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocityX = -speed;
        }else if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocityX = speed;
        }else{
            rb.velocityX = 0f;
        }

    }
}
