using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //public float speed = 1.5f; 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * StaticComponent.GetCurrentSpeed() * Time.deltaTime, 0, 0, Space.World);
    }

    public void AutoDestruccion()
    {
        Destroy(gameObject);
    }
}
