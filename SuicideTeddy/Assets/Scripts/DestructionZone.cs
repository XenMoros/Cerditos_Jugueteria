using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    public InstantiateObjects iObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Estanteria") || other.gameObject.CompareTag("Pelota"))
        {
            other.GetComponent<Scroll>().AutoDestruccion();

            iObjects.ReordenarLista();
        }
    }
}
