using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float jumpForce = 10f;
    private float minX = -8.9f;
    private float maxX = 6.1f;
    private int health = 100;
    PlayerHealth healthObject;

    private bool letJump = false;

    // Start is called before the first frame update
    void Start()
    {
        healthObject = (PlayerHealth)FindObjectOfType(typeof(PlayerHealth));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 hamsterPos = new Vector2(transform.position.x, transform.position.y);
        hamsterPos.x += Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        hamsterPos.x = Mathf.Clamp(hamsterPos.x, minX, maxX);
        transform.position = hamsterPos;

        if (Input.GetButtonDown("Vertical") && letJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") {
            letJump = true;
        }
        else if(collision.collider.tag == "Enemy")
        {
            health -= 10;
            if (health <= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<SceneLoader>().LoadNextScene();
            }
            else {
                healthObject.healtValue -= 10;
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            letJump = false;
        }
    }

}
