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
    [Range(0f,100f)] public float velocidadHorizontal = 8f;
    [Range(0f, 100f)] public float velocidadSalto = 10f;

    [Range(0f, 100f)] public float impulsoHorizontal = 50f;

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

        if (Input.GetKeyDown(KeyCode.Space) && !onAir)
        {
                personageRB.AddForce(new Vector2(0, velocidadSalto), ForceMode.Impulse);
                personageRB.velocity = new Vector2(personageRB.velocity.x/2,personageRB.velocity.y);
        }

        float impulsoActual = impulsoHorizontal;

        if (onAir) impulsoActual /= 10;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (personageRB.velocity.x < velocidadHorizontal)
            {
                personageRB.AddForce(new Vector2(impulsoActual, 0), ForceMode.Force);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (personageRB.velocity.x > -velocidadHorizontal)
            {
                personageRB.AddForce(new Vector2(-impulsoActual, 0), ForceMode.Force);
            }
        }
        else
        {
            personageRB.AddForce(new Vector2(-2 * personageRB.velocity.x, 0), ForceMode.Force);
        }
    }

}
