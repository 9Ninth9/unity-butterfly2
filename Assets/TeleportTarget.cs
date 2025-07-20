using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportOnButtonPress : MonoBehaviour
{
    public GameObject teleportTarget;
    public XRRayInteractor rayInteractor; // Optional if you want to use ray in future

    public void TeleportPlayer()
    {
        XRInteractorLineVisual[] visuals = FindObjectsOfType<XRInteractorLineVisual>();
        foreach (var visual in visuals)
        {
            visual.enabled = false; // Optional: Hide line visuals
        }

        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        xrOrigin.transform.position = teleportTarget.transform.position;
        xrOrigin.transform.rotation = teleportTarget.transform.rotation;
    }
}