using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public List<GameObject> estanterias = new List<GameObject>();
    public List<GameObject> instantiatedObjects = new List<GameObject>();
    public List<GameObject> pelotas = new List<GameObject>();
    public List<GameObject> instantiatedPelotas = new List<GameObject>();
    
    public SpawnPoints spawns;

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

            instantiatedObjects.Add(Instantiate(estanterias[intEstanterias], spawns.spawnEstanteria.transform.position, spawns.spawnEstanteria.transform.rotation, cosasMoviles));

            timeEstantes = Random.Range(3,5);
        }

        if (instantiatedPelotas.Count <= 0 && timePelotas <=0)
        {
            instantiatedPelotas.Add(Instantiate(pelotas[intPelotas], spawns.spawnPelota.transform.position, spawns.spawnPelota.transform.rotation, cosasMoviles));

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

[System.Serializable]
public class SpawnPoints
{
    public Transform spawnEstanteria;
    public Transform spawnPelota;

}
