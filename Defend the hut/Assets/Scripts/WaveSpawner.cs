using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
    {
    private Enemy enemy;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    private void Start()
        {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        }

    // Update is called once per frame
    private void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            spawnPosition = new Vector3(transform.position.x, transform.position.y + 1, Random.Range(-3.3f, 3.3f));
            Instantiate(enemy.gameObject, spawnPosition, transform.rotation);
            }
        }

    private void SpawnEnemy()
        {
        }
    }