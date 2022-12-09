using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject boss;

    private float delay = 0;

    [SerializeField] float cooldownManager;
    [SerializeField] int nbEnemy = 1;
    [SerializeField] int nbBoss = 1;

    private void Start()
    {
        delay = 0;
    }

    void Update()
    {

        if (delay <= 0 && nbEnemy > 0)
        {
            int randSpawnPoint = Random.Range(0, spawnPoint.Length);

            Instantiate(enemy, spawnPoint[randSpawnPoint].position, transform.rotation);

            delay = cooldownManager;
            nbEnemy--;
        }
        else if (delay <= 0 && nbBoss > 0)
        {
            int randSpawnPoint = Random.Range(0, spawnPoint.Length);

            Instantiate(boss, spawnPoint[randSpawnPoint].position, transform.rotation);

            delay = cooldownManager;
            nbBoss--;
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }

    public void EndSpawn()
    {
        enabled = false;
    }
}
