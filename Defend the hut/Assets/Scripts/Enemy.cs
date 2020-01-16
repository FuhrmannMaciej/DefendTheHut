using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
    {
    private float enemyDamage = 5;
    private Player player;
    private float attackRate = 3;
    public float enemyHealth;
    private float startEnemyHealth = 50;

    public bool IsDead = false;

    // Start is called before the first frame update
    private void Start()
        {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyHealth = startEnemyHealth;
        }

    // Update is called once per frame
    private void Update()
        {
        }

    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("WallTrigger"))
            {
            StartCoroutine(Attack());
            }
        }

    private IEnumerator Attack()
        {
        while (!IsDead)
            {
            player.playerHealth -= enemyDamage;
            yield return new WaitForSeconds(attackRate);
            }
        }

    public void EnemyDied()
        {
        Destroy(this.gameObject);
        IsDead = true;
        }
    }