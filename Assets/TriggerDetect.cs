using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ExhibitTrigger : MonoBehaviour
{
    public Canvas exhibitCanvas;

    private void Start()
    {
        exhibitCanvas.enabled = false; // Hide canvas on game start
    }

    private void OnTriggerEnter(Collider other)
    {
    
    if (other.CompareTag("Player"))
    {
        exhibitCanvas.enabled = true;
    }
}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exhibitCanvas.enabled = false;
        }
    }
}