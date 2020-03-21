using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
    {
    public int enemiesAlive = 0;

    public Day[] days;
    private Day day;
    private int dayIndex = 0;
    public GameObject enemyToSpawn;

    public UpgradeMenu upgradeMenuScript;

    // Start is called before the first frame update
    private void Start()
        {
        StartCoroutine(SpawnDayWave());
        }

    // Update is called once per frame
    private void Update()
        {
        TimerPerDay();
        if (enemiesAlive == 0 && day.lengthOfDay <= 0)
            {
            dayIndex++;
            day.lengthOfDay = 90f;
            upgradeMenuScript.OpenUpgradeMenu();
            }
        }

    public IEnumerator SpawnDayWave()
        {
        if (days.Length > dayIndex)
            {
            day = days[dayIndex];
            //spawns only one enemy in next days fix it !
            while (day.lengthOfDay > 5)
                {
                SpawnEnemy();
                yield return new WaitForSeconds(Random.Range(2, 5));
                }
            }
        }

    private void SpawnEnemy()
        {
        enemyToSpawn = ObjectPooler.SharedInstance.GetPooledObject(0);
        Debug.Log("Spawning");
        if (enemyToSpawn != null)
            {
            enemyToSpawn.SetActive(true);
            enemiesAlive++;
            }
        }

    private void TimerPerDay()
        {
        if (day.lengthOfDay > 0)
            {
            day.lengthOfDay -= Time.deltaTime;
            }
        }
    }