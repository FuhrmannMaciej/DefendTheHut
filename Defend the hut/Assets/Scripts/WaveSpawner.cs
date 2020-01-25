using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
    {
    private Vector3 spawnPosition;
    public int enemiesAlive = 0;
    public EnemyBlueprint enemyBlueprint;

    public Day[] days;
    private Day day;

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
        day = days[day.dayCount];

        for (int i = 0; i < day.enemiesPerDay.Length; i++)
            {
            SpawnEnemy(enemyBlueprint.enemies[i]);
            yield return new WaitForSeconds(day.rate);
            }

        dayCount++;
        }

    private void SpawnEnemy(GameObject enemy)
        {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + 1f, Random.Range(-3.3f, 3.3f));
        Instantiate(enemy, spawnPosition, transform.rotation);
        enemiesAlive++;
        }

    private void dayLengthTimer()
        {
        while (day.lengthOfDay > 0)
            {
            day.lengthOfDay -= Time.deltaTime;
            }
        }
    }