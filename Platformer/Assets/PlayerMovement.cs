using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //variable
    public float speed;     //control speed of movement
    float move;             //control direction of movement

    public float jump;

    public bool isJumping;

    Rigidbody2D rb;         //store the rigidbody of an object


    public int maxHealth;       //determines max amount of health the player can have
    public int currentHealth;   //tracks current health of the player


    public Transform startPos;

    public GameObject health1;
    public GameObject health2;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jump = 400f;
        rb = GetComponent<Rigidbody2D>();       //get the rigidbody of the object

        maxHealth = 3;                  //set max health to two
        currentHealth = maxHealth;      //set current health to max health
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");             //when any of the horizontal keys are pressed
        rb.velocity = new Vector2(speed * move, rb.velocity.y); //change the value of the rb to move

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Debug.Log("space");
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;                        //lower health
        transform.position = new Vector2(startPos.position.x, startPos.position.y);

        if (currentHealth == 2)
        {
            health2.SetActive(false);
        }

        if (currentHealth == 1)
        {
            health1.SetActive(false);
        }


        if (currentHealth <= 0)                         //if health equal zero
        {
            SceneManager.LoadScene("GameOver");         //go to GameOver Scene

        }
    }
    /*
        void OnTriggerEnter2D(Collider2D coll)
        {

        }*/

}