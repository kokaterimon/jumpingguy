﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour{

    public GameObject enemyPrefab;
    public float generatorTimer = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 0f, generatorTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}