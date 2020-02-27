using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
    {
    public float speed;

    // Start is called before the first frame update
    private void Start()
        {
        }

    // Update is called once per frame
    private void Update()
        {
        Move();
        }

    private void Move()
        {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.CompareTag("WallTrigger"))
            {
            Debug.Log("Colliding");
            enabled = false;
            }
        }
    }