using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{

    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = (Score)FindObjectOfType(typeof(Score));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Enemy")
        {
            score.scoreValue += 10;
        }
    }

}
