using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movimiento : MonoBehaviour
{
    Rigidbody personageRB;
    [Range(0f,10f)] float velocidadHorizontal;
    [Range(0f, 10f)] float velocidadSalto;

    // Assign components on reset of the class
    void Reset()
    {
        personageRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Right))
        {
            if(personageRB.velocity.X < velocidadHorizontal)
            {
                personageRB.AddForce(new Vector3(velocidadHorizontal, 0, 0));
            }
        }

        if (Input.GetKey(KeyCode.Left))
        {
            if (personageRB.velocity.X > -velocidadHorizontal)
            {
                personageRB.AddForce(new Vector3(-velocidadHorizontal, 0, 0));
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (personageRB.velocity.Y == 0)
            {
                personageRB.AddForce(new Vector3(0, velocidadSalto, 0));
            }
        }
    }
}
