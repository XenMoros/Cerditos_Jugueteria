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

    [Range(0f,10f)] public float tiempoInvencible;
    float timerInvencible;

    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timerInvencible = tiempoInvencible + 1;
    }

    private void Update()
    {
        if(invencible)
        {
            timerInvencible += Time.deltaTime;
            if(timerInvencible >= tiempoInvencible)
            {
                invencible = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!invencible) PerderVidas();
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
        timerInvencible = 0;
        invencible = true;

        if (currentLives <= 0)
        {
            Kill();
        }

    }

    private void Kill()
    {
        gameManager.EndGame();
    }
}
