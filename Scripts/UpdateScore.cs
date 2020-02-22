using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Score score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
       if (otherCollider.tag == "Enemy")
       {
            Debug.Log(2222);
            score.scoreValue += 10;
        }
    }

}
