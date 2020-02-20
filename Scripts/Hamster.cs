using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float jumpForce = 10f;

    private bool letJump = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed, 0f, 0f);
        
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
            Destroy(gameObject);
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
