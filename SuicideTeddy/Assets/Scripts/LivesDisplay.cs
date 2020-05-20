using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public int umbral = 1;
    public UnityEngine.UI.Image imagen;

    public void SetVisibility(int current)
    {
        if (current < umbral) imagen.enabled = false; 
        else imagen.enabled = true;

    }
}
