using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Vidas : MonoBehaviour
{
    int maxLives = 3;
    public int currentLives;
    public bool invencible;

    [Range(0f,10f)] public float tiempoInvencible = 3;
    float timerInvencible;

    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timerInvencible = tiempoInvencible + 1;
        gameManager.ActualizarVidas(currentLives);
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
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!invencible) PerderVidas();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("DeadZone"))
        {
            currentLives = 0;
            gameManager.ActualizarVidas(currentLives);
            Kill();
        }
    }

    private void PerderVidas()
    {
        currentLives -= 1;
        timerInvencible = 0;
        invencible = true;

        gameManager.ActualizarVidas(currentLives);

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
