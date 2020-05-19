using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlataformaAtravesable : MonoBehaviour
{
    BoxCollider componentCollider;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {

        componentCollider = transform.GetComponent<BoxCollider>();

        componentCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.position.y <= (transform.position.y + (componentCollider.size.y*transform.lossyScale.y)))
            {
                componentCollider.isTrigger = true;
            }
            else
            {
                componentCollider.isTrigger = false;
            }
        }
        else
        {
            try
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch
            {
                
            }
        }
        
    }
}
