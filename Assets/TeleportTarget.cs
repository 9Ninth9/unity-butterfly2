using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportOnButtonPress : MonoBehaviour
{
    public GameObject teleportTarget;

    public void TeleportPlayer()
    {
        // Store original enabled states
        XRRayInteractor[] rays = FindObjectsOfType<XRRayInteractor>();
        foreach (var ray in rays)
        {
            bool wasEnabled = ray.enabled;
            ray.enabled = false;
            ray.enabled = wasEnabled; // restore previous state
        }

        // Teleport XR Origin
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        Transform cameraTransform = xrOrigin.Camera.transform;

        if (xrOrigin != null && teleportTarget != null)
        {
            // Teleport position
            xrOrigin.transform.position = teleportTarget.transform.position;

            // Calculate angle difference between current head direction and pad’s forward
            Vector3 headsetForward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
            Vector3 padForward = new Vector3(teleportTarget.transform.forward.x, 0, teleportTarget.transform.forward.z).normalized;

            float angleOffset = Vector3.SignedAngle(headsetForward, padForward, Vector3.up);

            // Apply rotation to rig
            xrOrigin.transform.Rotate(Vector3.up, angleOffset);
        }
    }
}