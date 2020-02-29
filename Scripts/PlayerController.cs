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
        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        transform.position = playerPos;

        if (Input.GetButtonDown("Vertical") && letJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
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
            letJump = true;
        }
    }

    public void HealthHeandler(int damage) {
        Debug.Log(damage);
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
