using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnKeyPress : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign your VideoPlayer component in the Inspector

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Play the video if it's not already playing
            if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
            }
        }
    }
}
