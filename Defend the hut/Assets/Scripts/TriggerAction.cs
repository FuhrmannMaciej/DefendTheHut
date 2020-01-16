using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour
    {
    private MoveEnemy moveEnemy;

    // Start is called before the first frame update
    private void Start()
        {
        moveEnemy = GameObject.Find("Enemy").GetComponent<MoveEnemy>();
        }

    // Update is called once per frame
    private void Update()
        {
        }

    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("Enemy"))
            {
            moveEnemy.enabled = false;
            }
        }
    }