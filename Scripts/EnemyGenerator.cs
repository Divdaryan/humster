﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemies;
    GameObject enamyInstanse;
    bool spawn = true;
    float currentSpeed = 1f;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(1f);
            int y = Random.Range(-3, 2);
            int x = 30;
            transform.position = new Vector2(x, y);
            int random = Random.Range(0, enemies.Length);
            enamyInstanse = Instantiate(enemies[random], transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (enamyInstanse)
        {
            enamyInstanse.transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
    }
}
