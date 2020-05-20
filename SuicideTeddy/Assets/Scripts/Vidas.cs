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
    public AnimatorController aController;
    public PlayerAudio playerAudio;

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
        Debug.Log(invencible);

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
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("lolaso");

            if (!invencible) PerderVidas();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            Debug.Log("Enganchao");

            if(currentLives > 0)
            {
                currentLives = 0;
                gameManager.ActualizarVidas(currentLives);
                Kill();
            }
        }
    }

    private void PerderVidas()
    {
        if(currentLives > 0)
        {
            currentLives -= 1;
            timerInvencible = 0;
            invencible = true;

            gameManager.ActualizarVidas(currentLives);

            if (currentLives <= 0)
            {
                Kill();
            }
            else
            {
                playerAudio.PlayAudio(1);
            }
        }
    }

    private void Kill()
    {
        playerAudio.PlayAudio(2);
        gameManager.gameAudio.audioSource.Stop();
        aController.ActivateDead();
    }
}
