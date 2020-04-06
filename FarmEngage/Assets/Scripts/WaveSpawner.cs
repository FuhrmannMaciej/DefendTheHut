using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
    {
    public int enemiesAlive = 0;

    public Day[] days;
    public Day day;
    public int dayIndex = 0;
    public GameObject enemyToSpawn;

    public UpgradeMenu upgradeMenuScript;
    public GameManager gameManager;
    public ObjectPooler OP;

    #region Singleton

    private static WaveSpawner waveSpawnerInstance;

    public static WaveSpawner Instance => waveSpawnerInstance;

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

    private void Awake()
        {
        MakeSingleton();
        OP = ObjectPooler.SharedInstance;
        }

    // Start is called before the first frame update
    private void Start()
        {
        enemiesAlive = 0;
        StartCoroutine(upgradeMenuScript.HidePanelWithDayNumber());
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

    //do something about object pooler !!

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
        enemyToSpawn = OP.GetPooledObject(0);

        if (enemyToSpawn != null)
            {
            enemyToSpawn.SetActive(true);
            enemiesAlive++;
            }
        }

    private void TimerPerDay()
        {
        if (day.lengthOfDay > 0 && day != null)
            {
            day.lengthOfDay -= Time.deltaTime;
            }
        }
    }