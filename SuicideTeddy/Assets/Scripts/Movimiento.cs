using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movimiento : MonoBehaviour
{
    public Rigidbody personageRB;
    public AnimatorController aController;
    public PlayerAudio playerAudio;

    [Range(0f,100f)] public float velocidadHorizontal = 8f;
    [Range(0f, 100f)] public float velocidadSalto = 10f;

    [Range(0f, 100f)] public float impulsoHorizontal = 33f;

    public Vidas vidas;

    bool onAir;

    // Assign components on reset of the class
    void Reset()
    {
        personageRB = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Math.Abs(personageRB.velocity.y) >= 0.1f)
        {
            onAir = true;
        }
        else
        {
            onAir = false;
        }

        if(vidas.currentLives > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !onAir)
            {
                personageRB.AddForce(new Vector2(0, velocidadSalto), ForceMode.Impulse);
                personageRB.velocity = new Vector2(personageRB.velocity.x / 2, personageRB.velocity.y);
                playerAudio.PlayAudio(0);
                aController.ActivateJump();
            }

            float impulsoActual = impulsoHorizontal;

            if (onAir) impulsoActual /= 10;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.eulerAngles = new Vector3(0, 90, 0);

                if (personageRB.velocity.x < velocidadHorizontal)
                {
                    personageRB.AddForce(new Vector2(impulsoActual * StaticComponent.GetCurrentSpeed(), 0), ForceMode.Force);
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.eulerAngles = new Vector3(0, -90, 0);

                if (personageRB.velocity.x > -velocidadHorizontal)
                {
                    personageRB.AddForce(new Vector2(-impulsoActual * StaticComponent.GetCurrentSpeed(), 0), ForceMode.Force);
                }
            }
            else
            {
                personageRB.AddForce(new Vector2(-4 * personageRB.velocity.x, 0), ForceMode.Force);
            }

        }
        else
        {
            personageRB.AddForce(new Vector2(-4 * personageRB.velocity.x, 0), ForceMode.Force);
        }

    }

    public void ImpulsateJump()
    {
        personageRB.AddForce(new Vector2(0, velocidadSalto), ForceMode.Impulse);
        personageRB.velocity = new Vector2(personageRB.velocity.x / 2, personageRB.velocity.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {
            aController.ActivateHitDown();
        }
    }



}
