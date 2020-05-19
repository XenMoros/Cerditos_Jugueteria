﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenarToys : MonoBehaviour
{

    public List<GameObject> Juguetes = new List<GameObject>();
    public List<Transform> Posiciones = new List<Transform>();

    int jugueteRandom;
    //int posicion = 0;

    // Start is called before the first frame update
    void Start()
    {


        for (int i=0; i < Posiciones.Count; i++)
        {
            jugueteRandom = Random.Range(0, Juguetes.Count);
            Instantiate(Juguetes[jugueteRandom], Posiciones[i].position, Juguetes[jugueteRandom].transform.rotation, transform.parent);
        }
    }
}