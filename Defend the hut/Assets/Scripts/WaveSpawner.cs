using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
    {
    private Vector2 spawnPosition;
    public int enemiesAlive = 0;

    public Day[] days;
    private Day day;
    private int dayIndex = 0;
    private EnemyBlueprint enemyToSpawn;

    // Start is called before the first frame update
    private void Start()
        {
        StartCoroutine(SpawnDayWave());
        }

    // Update is called once per frame
    private void Update()
        {
        timerPerDay();
        }

    private IEnumerator SpawnDayWave()
        {
        if (days.Length > dayIndex)
            {
            day = days[dayIndex];
            while (day.lengthOfDay > 5)
                {
                enemyToSpawn = day.enemiesPerDay[Random.Range(0, day.enemiesPerDay.Length)];
                SpawnEnemy(enemyToSpawn.enemy);
                yield return new WaitForSeconds(enemyToSpawn.enemyRate);
                }

            dayIndex++;
            }
        }

    private void SpawnEnemy(GameObject enemy)
        {
        spawnPosition = new Vector2(transform.position.x, transform.position.y + Random.Range(-4.0f, 3f));
        Instantiate(enemy, spawnPosition, transform.rotation);
        enemiesAlive++;
        }

    private void timerPerDay()
        {
        if (day.lengthOfDay > 0)
            {
            day.lengthOfDay -= Time.deltaTime;
            }
        else
            {
            StartCoroutine(SpawnDayWave());
            }
        }
    }