using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallerToy : MonoBehaviour
{

    public Rigidbody objectRB;
    bool comprobado;

    // Start is called before the first frame update
    void Start()
    {
        objectRB.useGravity = false;
        comprobado = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallZone") && !comprobado)
        {
            if (Random.Range(0f, 1f) < 0.4f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -5);
                objectRB.AddForce(10 * Vector3.down, ForceMode.Impulse);
                objectRB.useGravity = true;
                comprobado = true;
            }
        }
    }
}
