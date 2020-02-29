using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 10;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = (PlayerController)FindObjectOfType(typeof(PlayerController));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.HealthHeandler(damage);
        }
    }
}
