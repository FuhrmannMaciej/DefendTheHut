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
    public GameManager gameManager;

    #region Singleton

    private static WaveSpawner waveSpawnerInstance;

    public static WaveSpawner Instance => waveSpawnerInstance;

    private void Awake()
        {
        MakeSingleton();
        }

    private void MakeSingleton()
        {
        if (waveSpawnerInstance != null && waveSpawnerInstance != this)
            {
            Destroy(gameObject);
            }
        else
            {
            waveSpawnerInstance = this;
            }
        }

    #endregion Singleton

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

    //REMINDER!! TODO!! panel day number attach to dayindex
    //spawning should be working now properly
    public IEnumerator SpawnDayWave()
        {
        if (days.Length > dayIndex)
            {
            day = days[dayIndex];

            while (day.lengthOfDay > 5)
                {
                yield return new WaitForSeconds(Random.Range(2, 5));
                SpawnEnemy();
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