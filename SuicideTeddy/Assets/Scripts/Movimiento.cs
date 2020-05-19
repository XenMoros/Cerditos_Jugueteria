using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Movimiento : MonoBehaviour
{
    public Rigidbody2D personageRB;
    [Range(0f,10f)] public float velocidadHorizontal = 5f;
    [Range(0f, 10f)] public float velocidadSalto = 5f;

    // Assign components on reset of the class
    void Reset()
    {
        personageRB = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(personageRB.velocity);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(personageRB.velocity.x < velocidadHorizontal)
            {
                personageRB.AddForce(new Vector2(10, 0),ForceMode2D.Force);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (personageRB.velocity.x > -velocidadHorizontal)
            {
                personageRB.AddForce(new Vector2(-10, 0), ForceMode2D.Force);
            }
        }
        else
        {
            personageRB.AddForce(new Vector2(-2*personageRB.velocity.x,0), ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (personageRB.velocity.y == 0)
            {
                personageRB.AddForce(new Vector2(0, velocidadSalto),ForceMode2D.Impulse);
            }
        }
    }
}
