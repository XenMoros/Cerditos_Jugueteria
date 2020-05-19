using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float baseSpeed = 1f; 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-baseSpeed * StaticComponent.GetCurrentSpeed() * Time.deltaTime, 0, 0, Space.World);
    }

    public void AutoDestruccion()
    {
        Destroy(gameObject);
    }
}
