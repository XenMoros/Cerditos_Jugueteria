using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParedes : MonoBehaviour
{
    public float scrollSpeed;
    Renderer rend;

    public bool moverY;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;


        if (!moverY)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
        }
        else
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
        }
        
    }
}
