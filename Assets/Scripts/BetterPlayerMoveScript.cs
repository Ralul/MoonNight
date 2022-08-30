using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerMoveScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float moveSpeed = 10;
    private float jumpforce = 30f;
    private float Jumpinfly = 10f;
    private bool isJumping;
    private float jumpTimeCounter;
    private float jumpTime;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //Put non physics based movement in here
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            

            transform.position += transform.right * (Time.deltaTime * moveSpeed);

            Debug.Log("Right");

        }
        else if (Input.GetKey(KeyCode.A))
        {
            

            transform.position -= transform.right * (Time.deltaTime * moveSpeed);

            Debug.Log("Left");

        }
        

    }



    //Put physica based movement in here
    private void FixedUpdate()
    {
        if (!isJumping && Input.GetKey(KeyCode.W))
        {
            Debug.Log("Jump");

            rb2d.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);

        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb2d.AddForce(new Vector2(0f, Jumpinfly), ForceMode2D.Impulse);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }

}
