using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
    {
    private float enemyDamage = 5;
    public Player playerScript;
    private float attackRate = 3;
    public float enemyHealth;
    private float enemyHealthStart = 50;
    private WaveSpawner waveSpawner;

    public bool IsDead = false;

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
            Debug.Log("Attacking!");
            }
        }

    private IEnumerator Attack()
        {
        while (!IsDead && playerScript.playerHealth >= 0)
            {
            playerScript.HurtPlayer(enemyDamage);
            yield return new WaitForSeconds(attackRate);
            }
        }

    public void EnemyHurt(float damage)
        {
        enemyHealth -= damage;
        }

    public void SetMaxEnemyHealth()
        {
        enemyHealth = enemyHealthStart;
        }

    public void EnemyDied()
        {
        if (!IsDead)
            {
            Destroy(gameObject);
            IsDead = true;
            waveSpawner.enemiesAlive--;
            }
        }
    }