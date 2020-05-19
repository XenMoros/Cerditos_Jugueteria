using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public List<GameObject> estanterias = new List<GameObject>();
    public List<GameObject> instantiatedObjects = new List<GameObject>();
    public List<GameObject> pelotas = new List<GameObject>();
    public List<GameObject> instantiatedPelotas = new List<GameObject>();

    public float timeEstantes = 0;
    public float timePelotas;

    public Transform generator;
    public Transform cosasMoviles;

    public int intEstanterias;
    public int intPelotas = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject objeto in GameObject.FindGameObjectsWithTag("Estanteria"))
        {
            instantiatedObjects.Add(objeto);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeEstantes -= Time.deltaTime;
        timePelotas -= Time.deltaTime;

        if (instantiatedObjects.Count <= 5 && timeEstantes <= 0)
        {
            intEstanterias = Random.Range(0, 2);

            instantiatedObjects.Add(Instantiate(estanterias[intEstanterias], generator.position, Quaternion.identity, cosasMoviles));

            timeEstantes = Random.Range(3,5);
        }

        if (instantiatedPelotas.Count <= 0 && timePelotas <=0)
        {
            instantiatedPelotas.Add(Instantiate(pelotas[intPelotas], generator.position, Quaternion.identity, cosasMoviles));

            timePelotas = Random.Range(5, 10);
        }

        instantiatedObjects.TrimExcess();
        instantiatedPelotas.TrimExcess();
    }

    public void ReordenarLista()
    {
        instantiatedObjects.RemoveAll(estante => estante == null);
        instantiatedPelotas.RemoveAll(estante => estante == null);
    }

    
}
