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
    private TouchPhase touchPhase = TouchPhase.Began;

    public string enemyTag = "Enemy";

    private float reloadTime = 2;
    private bool isReloaded = true;

    // Start is called before the first frame update
    private void Start()
        {
        SetStartHealth();
        }

    // Update is called once per frame
    private void Update()
        {
        if (playerHealth <= 0)
            {
            PlayerDied();
            }
        if (IsScreenTouched())
            {
            UpdateTarget();
            Shoot();
            StartCoroutine(Reload());
            }
        }

    private bool IsScreenTouched()
        {
        if (Input.touchCount == 1 && isReloaded && Input.GetTouch(0).phase == touchPhase)
            {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            return true;
            }
        else
            {
            return false;
            }
        }

    private void Shoot()
        {
        if (enemyScript != null)
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
        GameObject touchedObject = null;

        if (Physics.Raycast(ray, out hit))
            {
            if (hit.collider != null)
                {
                touchedObject = hit.transform.gameObject;
                Debug.Log(touchedObject);
                }
            }

        if (touchedObject != null && touchedObject.CompareTag(enemyTag))
            {
            enemyScript = touchedObject.GetComponent<Enemy>();
            Debug.Log("Accessing script");
            }
        else
            {
            enemyScript = null;
            }
        }
    }