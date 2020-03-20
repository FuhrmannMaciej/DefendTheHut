using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
    {
    // private Vector2 spawnPosition;
    public int enemiesAlive = 0;

    public Day[] days;
    private Day day;
    private int dayIndex = 0;
    public GameObject enemyToSpawn;

    public GameObject upgradeMenu;
    public UpgradeMenu upgradeMenuScript;

    public GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
        {
        StartCoroutine(SpawnDayWave());
        }

    // Update is called once per frame
    private void Update()
        {
        TimerPerDay();
        }

    private IEnumerator SpawnDayWave()
        {
        if (days.Length > dayIndex)
            {
            day = days[dayIndex];

            while (day.lengthOfDay > 5)
                {
                // enemyToSpawn = day.enemiesPerDay[Random.Range(0, day.enemiesPerDay.Length)];
                SpawnEnemy();
                yield return new WaitForSeconds(8f);
                }

            dayIndex++;
            }
        }

    private void SpawnEnemy()
        {
        //  spawnPosition = new Vector2(transform.position.x, transform.position.y + Random.Range(-4.0f, 3f));
        //   Instantiate(enemy, spawnPosition, transform.rotation);

        enemyToSpawn = ObjectPooler.SharedInstance.GetPooledObject(0);
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
        else
            {
            gameManager.isGamePaused = true;
            upgradeMenu.SetActive(true);
            if (upgradeMenuScript.ContinueButton())
                {
                upgradeMenu.SetActive(false);
                StartCoroutine(SpawnDayWave());
                }
            }
        }
    }