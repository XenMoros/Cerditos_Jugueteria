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
            comprobado = true;

            if (Random.Range(0f, 1f) < 0.07f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -5);
                objectRB.AddForce(10 * Vector3.down, ForceMode.Impulse);
                objectRB.AddTorque(Random.Range(80f,160f) * Vector3.left + Random.Range(-1f,1f)*50f*Vector3.forward);
                objectRB.useGravity = true;
                
            }
        }
    }
}
