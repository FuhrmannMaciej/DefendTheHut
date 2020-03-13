using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    public int playerHealth;
    private int playerHealthStart = 100;

    public Enemy enemyScript;
    private Vector3 ray;
    private Vector2 tapPosition;
    private RaycastHit2D hit;
    private TouchPhase touchPhase = TouchPhase.Began;

    public Weapon[] weapons;
    public Weapon equipedWeapon;
    public int currentWeapon = 0;

    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    private void Start()
        {
        SetStartHealth();
        SetStartWeapon();
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
            if (equipedWeapon.ammo <= 0)
                {
                StartCoroutine(Reload());
                }
            }
        }

    private bool IsScreenTouched()
        {
        if (Input.touchCount == 1 && equipedWeapon.ammo > 0 && Input.GetTouch(0).phase == touchPhase)
            {
            ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            tapPosition = new Vector2(ray.x, ray.y);
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
            enemyScript.EnemyHurt(equipedWeapon.damage);
            equipedWeapon.ammo--;
            if (enemyScript.enemyHealth <= 0)
                {
                enemyScript.EnemyDied();
                }
            }
        else
            {
            equipedWeapon.ammo--;
            }
        }

    private IEnumerator Reload()
        {
        yield return new WaitForSeconds(equipedWeapon.reloadTime);
        equipedWeapon.ammo = equipedWeapon.ammoCapacity;
        }

    public void HurtPlayer(int damage)
        {
        playerHealth -= damage;
        }

    private void SetStartWeapon()
        {
        equipedWeapon = weapons[0];
        equipedWeapon.ammo = equipedWeapon.ammoCapacity;
        }

    public void SetStartHealth()
        {
        playerHealth = playerHealthStart;
        }

    private void PlayerDied()
        {
        Time.timeScale = 0.0f;
        }

    private void UpdateTarget()
        {
        GameObject touchedObject = null;
        hit = Physics2D.Raycast(tapPosition, Vector2.zero);

        //    if (Physics2D.Raycast(tapPosition, Vector2.zero))
        //       {
        if (hit.collider != null)
            {
            touchedObject = hit.transform.gameObject;
            }
        //    }

        if (touchedObject != null && touchedObject.CompareTag(enemyTag))
            {
            enemyScript = touchedObject.GetComponent<Enemy>();
            }
        else
            {
            enemyScript = null;
            }
        }
    }