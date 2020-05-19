using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Movimiento : MonoBehaviour
{
    public Rigidbody2D personageRB;
    [Range(0f,10f)] public float velocidadHorizontal = 5f;
    [Range(0f, 10f)] public float velocidadSalto = 5f;

    [Range(0f, 100f)] public float impulsoHorizontal = 10f;

    bool onAir;

    // Assign components on reset of the class
    void Reset()
    {
        personageRB = transform.GetComponent<Rigidbody2D>();
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
                personageRB.AddRelativeForce(new Vector2(0, velocidadSalto), ForceMode2D.Impulse);
                personageRB.velocity = new Vector2(personageRB.velocity.x/2,personageRB.velocity.y);
        }

        float impulsoActual = impulsoHorizontal;

        if (onAir) impulsoActual /= 10;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (personageRB.velocity.x < velocidadHorizontal)
            {
                personageRB.AddRelativeForce(new Vector2(impulsoActual, 0), ForceMode2D.Force);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (personageRB.velocity.x > -velocidadHorizontal)
            {
                personageRB.AddRelativeForce(new Vector2(-impulsoActual, 0), ForceMode2D.Force);
            }
        }
        else
        {
            personageRB.AddForce(new Vector2(-2 * personageRB.velocity.x, 0), ForceMode2D.Force);
        }
    }

}
