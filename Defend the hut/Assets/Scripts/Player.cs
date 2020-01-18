using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    public float playerHealth;
    private float startPlayerHealth = 100;
    private GameObject[] enemy;
    private Enemy enemyScript;
    private float playerDamage = 30;
    private Ray ray;
    private RaycastHit hit;

    private float reloadTime = 2;
    private bool isReloaded = true;

    // Start is called before the first frame update
    private void Start()
        {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        playerHealth = startPlayerHealth;
        }

    // Update is called once per frame
    private void Update()
        {
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
        if (hit.collider.gameObject.CompareTag("Enemy"))
            {
            enemyScript.enemyHealth -= playerDamage;
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
    }