using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportscript : MonoBehaviour
{
    public Transform teleportTarget; // Assign the target position in the Inspector

    // Function to teleport the player
    public void Teleport()
    {
        if (teleportTarget != null)
        {
            transform.position = teleportTarget.position;
        }
    }
}

