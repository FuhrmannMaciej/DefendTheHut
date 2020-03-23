using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
    {
    private int enemyDamage = 5;
    private int attackRate = 3;
    public int enemyHealth;
    private int enemyHealthStart = 50;

    public Player playerScript;
    public WaveSpawner waveSpawner;
    public List<GameObject> activeEnemies;

    // Start is called before the first frame update
    private void Start()
        {
        SetMaxEnemyHealth();
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
        while (playerScript.playerHealth >= 0)
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
        if (waveSpawner.enemyToSpawn != null && waveSpawner.enemyToSpawn.activeInHierarchy)
            {
            waveSpawner.enemiesAlive--;
            }
        }
    }