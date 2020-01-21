using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
    {
    public int enemiesAlive;
    private Vector3 spawnPosition;
    public float timeBetweenWaves = 3;

    private int dayCount = 0;

    public Day[] days;

    // Start is called before the first frame update
    private void Start()
        {
        StartCoroutine(SpawnDayWave());
        }

    // Update is called once per frame
    private void Update()
        {
        }

    private IEnumerator SpawnDayWave()
        {
        Day day = days[dayCount];

        for (int i = 0; i < day.count; i++)
            {
            SpawnEnemy(day.enemy);
            yield return new WaitForSeconds(timeBetweenWaves);
            }
        dayCount++;
        }

    private void SpawnEnemy(GameObject enemy)
        {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + 1, Random.Range(-3.3f, 3.3f));
        Instantiate(enemy, spawnPosition, transform.rotation);
        enemiesAlive++;
        }
    }