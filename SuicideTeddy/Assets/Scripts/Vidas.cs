using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Vidas : MonoBehaviour
{
    int maxLives;
    int currentLives;
    bool invencible;

    GameManager gameManager;

    private void Reset()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            PerderVidas();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            Kill();
        }
    }

    private void PerderVidas()
    {
        currentLives -= 1;

        if(currentLives <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        gameManager.EndGame();
    }
}
