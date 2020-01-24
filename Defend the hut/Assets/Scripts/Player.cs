using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    public float playerHealth;
    private float playerHealthStart = 100;

    public Enemy enemyScript;
    private float playerDamage = 30;
    private Ray ray;
    private RaycastHit hit;

    private WaveSpawner waveSpawner;

    public string enemyTag = "Enemy";

    private float reloadTime = 2;
    private bool isReloaded = true;

    // Start is called before the first frame update
    private void Start()
        {
        waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>();
        InvokeRepeating("UpdateTarget", 0f, 1f);
        SetStartHealth();
        }

    // Update is called once per frame
    private void Update()
        {
        if (playerHealth <= 0)
            {
            PlayerDied();
            }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            {
            if (Input.GetMouseButtonDown(0) && isReloaded)
                {
                Shoot();
                StartCoroutine(Reload());
                }
            }
        }

    private void Shoot()
        {
        if (hit.collider.gameObject.CompareTag(enemyTag))
            {
            Debug.Log("Shooting!");

            enemyScript.EnemyHurt(playerDamage);
            isReloaded = false;
            if (enemyScript.enemyHealth <= 0)
                {
                enemyScript.EnemyDied();
                }
            }
        else
            {
            isReloaded = false;
            }
        }

    private IEnumerator Reload()
        {
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
        }

    public void HurtPlayer(float damage)
        {
        playerHealth -= damage;
        }

    public void SetStartHealth()
        {
        playerHealth = playerHealthStart;
        }

    private void PlayerDied()
        {
        Debug.Log("GameOver!");
        }

    private void UpdateTarget()
        {
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in waveSpawner.enemiesAlive)
            {
            if (Input.touchCount == 1)
                {
                Touch touch = Input.GetTouch(0);
                //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                var ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitInfo;
                Vector3 enemyPosition = Camera.main.ScreenToWorldPoint(enemy.transform.position);
                if (Physics.Raycast(ray, out hitInfo))
                    {
                    if (hitInfo.point == enemyPosition)
                        {
                        nearestEnemy = enemy;
                        Debug.Log("Nearest enemy set");
                        }
                    }
                }
            }

        if (nearestEnemy != null)
            {
            enemyScript = nearestEnemy.GetComponent<Enemy>();
            Debug.Log("Accessing script");
            }
        else
            {
            enemyScript = null;
            }
        }
    }