using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float jumpForce = 10f;
    private float minX = -8.9f;
    private float maxX = 6.1f;
    private int health = 100;
    PlayerHealth healthObject;
    private bool letJump = false;

    void Start()
    {
        healthObject = (PlayerHealth)FindObjectOfType(typeof(PlayerHealth));
    }

    void Update()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        playerPos.x += Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        if (playerPos.x > minX && Input.GetAxisRaw("Horizontal") == 0) 
        {
            playerPos.x -= 1f * Time.fixedDeltaTime * speed; 
        }
        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);

        transform.position = playerPos;

        if (Input.GetButtonDown("Vertical") && letJump)
        {
            GetComponent<Animator>().Play("foxy_jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0 && letJump)
        {
            GetComponent<Animator>().Play("super_fast_run");
        }
        else if (Input.GetButtonUp("Horizontal"))
        { 
            GetComponent<Animator>().Play("foxy-run");
        }

    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            letJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            GetComponent<Animator>().Play("foxy-run");
            letJump = true;
        }
    }

    public void HealthHeandler(int damage) {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
        else
        {
            healthObject.healtValue = health;
        }
    }
}
