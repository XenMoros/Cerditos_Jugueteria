using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public List<GameObject> estanterias = new List<GameObject>();
    public List<GameObject> instantiatedObjects = new List<GameObject>();

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

        if (instantiatedObjects.Count <= 4 && time <= 0)
        {
            intEstanterias = Random.Range(0, 2);

            instantiatedObjects.Add(Instantiate(estanterias[intEstanterias], generator.position, Quaternion.identity, cosasMoviles));

            time = Random.Range(3,5);
        }
    }

    
}
