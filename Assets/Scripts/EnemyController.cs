using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action OnPlayerDeath;
    Enemy[] enemies;

    void Start()
    {
        enemies = FindObjectsOfType<Enemy>(); 
    }

    // Update is called once per frame
    void Update()
    {
        bool isNeedExit = true;
        for (int i =0;i<enemies.Length;i++)
        {
            if (enemies[i] != null)
            {
                isNeedExit = false;
                break;
            }
        }
        if (isNeedExit)
        {
            OnPlayerDeath.Invoke();
        }
    }
}
