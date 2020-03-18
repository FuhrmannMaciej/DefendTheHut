using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
    {
    private int enemyDamage = 5;
    public Player playerScript;
    private int attackRate = 3;
    public int enemyHealth;
    private int enemyHealthStart = 50;
    public WaveSpawner waveSpawner;

    // Start is called before the first frame update
    private void Start()
        {
        waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>();
        SetMaxEnemyHealth();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

    // Update is called once per frame
    private void Update()
        {
        }

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.CompareTag("WallTrigger"))
            {
            StartCoroutine(Attack());
            }
        }

    private IEnumerator Attack()
        {
        while (playerScript.playerHealth >= 0 && !GameManager.instance.isGamePaused)
            {
            playerScript.HurtPlayer(enemyDamage);
            yield return new WaitForSeconds(attackRate);
            }
        }

    public void EnemyHurt(int damage)
        {
        enemyHealth -= damage;
        }

    public void SetMaxEnemyHealth()
        {
        enemyHealth = enemyHealthStart;
        }

    public void EnemyDied()
        {
        if (waveSpawner.enemyToSpawn != null)
            {
            waveSpawner.enemiesAlive--;
            waveSpawner.enemyToSpawn.SetActive(false);
            ObjectPooler.SharedInstance.AddObject(waveSpawner.enemyToSpawn);
            }
        }
    }