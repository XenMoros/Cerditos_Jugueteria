using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public List<GameObject> estanterias = new List<GameObject>();
    public List<GameObject> instantiatedObjects = new List<GameObject>();
    
    public SpawnPoints spawns;

    public float time = 0;
    public Transform generator;
    public Transform cosasMoviles;
    public int intEstanterias;

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
        time -= Time.deltaTime;

        if (instantiatedObjects.Count <= 5 && time <= 0)
        {
            intEstanterias = Random.Range(0, 2);

            instantiatedObjects.Add(Instantiate(estanterias[intEstanterias], spawns.spawnEstanteria.transform.position, spawns.spawnEstanteria.transform.rotation, cosasMoviles));

            time = Random.Range(3,5);
        }

        instantiatedObjects.TrimExcess();
    }

    public void ReordenarLista()
    {
        instantiatedObjects.RemoveAll(estante => estante == null);
    }

    
}

[System.Serializable]
public class SpawnPoints
{
    public Transform spawnEstanteria;
    public Transform spawnPelota;

}
