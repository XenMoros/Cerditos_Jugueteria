using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public List<GameObject> estanterias = new List<GameObject>();
    public List<GameObject> instantiatedObjects = new List<GameObject>();
    public List<GameObject> juguetes = new List<GameObject>();
    public List<GameObject> instantiatedJuguetes = new List<GameObject>();
    
    public SpawnPoints spawns;

    public float timeEstantes = 0;
    public float timeJuguetes;

    public Transform generator;
    public Transform cosasMoviles;

    public int intEstanterias;

    public float initialRandomEstantes = 6f, endRandomEstantes = 7.5f;
    public float initialRandomPelotas = 7.5f, endRandomPelotas = 20f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject objeto in GameObject.FindGameObjectsWithTag("Estanteria"))
        {
            instantiatedObjects.Add(objeto);
        }
    }

    public void Initialize()
    {
        foreach(GameObject juguete in instantiatedObjects)
        {
            if(juguete != null)
            {
                juguete.GetComponent<Scroll>().AutoDestruccion();
            }
        }

        instantiatedObjects.Clear();

        foreach (GameObject juguete in instantiatedJuguetes)
        {
            if (juguete != null)
            {
                juguete.GetComponent<Scroll>().AutoDestruccion();
            }
        }

        instantiatedJuguetes.Clear();

        foreach (GameObject juguete in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            juguete.GetComponent<Scroll>().AutoDestruccion();
        }

        timeEstantes = 1.0f;
        timeJuguetes = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeEstantes -= Time.deltaTime;
        timeJuguetes -= Time.deltaTime;

        if (instantiatedObjects.Count <= 5 && timeEstantes <= 0)
        {
            intEstanterias = Random.Range(0, 2);
            
            instantiatedObjects.Add(Instantiate(estanterias[intEstanterias], spawns.spawnEstanteria.transform.position, spawns.spawnEstanteria.transform.rotation, cosasMoviles));
            timeEstantes = Random.Range(initialRandomEstantes/StaticComponent.GetCurrentSpeed(), endRandomEstantes / StaticComponent.GetCurrentSpeed());

        }

        if (instantiatedJuguetes.Count <= 0 && timeJuguetes <=0)
        {
            int juegueteAInstanciar = Random.Range(0, juguetes.Count);
            Vector3 spawnPositionJuguete;
            if (juegueteAInstanciar == 0)
            {
                spawnPositionJuguete = spawns.spawnJuguetes.transform.position + Random.Range(2f, 4f) * Vector3.up;
            }
            else
            {
                spawnPositionJuguete = spawns.spawnJuguetes.transform.position;
            }
            instantiatedJuguetes.Add(Instantiate(juguetes[juegueteAInstanciar], spawnPositionJuguete, juguetes[juegueteAInstanciar].transform.rotation, cosasMoviles));

            timeJuguetes = Random.Range(initialRandomPelotas / StaticComponent.GetCurrentSpeed(), endRandomPelotas / StaticComponent.GetCurrentSpeed());
        }

        instantiatedObjects.TrimExcess();
        instantiatedJuguetes.TrimExcess();
    }

    public void ReordenarLista()
    {
        instantiatedObjects.RemoveAll(estante => estante == null);
        instantiatedJuguetes.RemoveAll(estante => estante == null);
    }

    
}

[System.Serializable]
public class SpawnPoints
{
    public Transform spawnEstanteria;
    public Transform spawnJuguetes;

}
