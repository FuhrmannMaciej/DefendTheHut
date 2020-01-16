using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    public float playerHealth;
    private float startPlayerHealth = 100;
    private Enemy enemy;
    private float playerDamage = 5;

    private float reloadTime = 2;

    // Start is called before the first frame update
    private void Start()
        {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        playerHealth = startPlayerHealth;
        StartCoroutine(Shoot());
        }

    // Update is called once per frame
    private void Update()
        {
        }

    private IEnumerator Shoot()
        {
        while (true)
            {
            if (Input.GetKeyDown(KeyCode.Space))
                {
                enemy.enemyHealth -= playerDamage;
                if (enemy.enemyHealth <= 0)
                    {
                    enemy.EnemyDied();
                    }
                yield return new WaitForSeconds(reloadTime);
                }
            }
        }
    }