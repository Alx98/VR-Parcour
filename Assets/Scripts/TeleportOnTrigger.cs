using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTrigger : MonoBehaviour
{
    public Transform teleportTarget; // Zielort für die Teleportation

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleportTarget != null)
            {
                Debug.Log("Teleporting to: " + teleportTarget.name + " at position " + teleportTarget.position);
                CharacterController controller = other.GetComponent<CharacterController>();
                if (controller != null)
                {
                    controller.enabled = false; // Deaktiviere kurz den CharacterController
                    other.transform.position = teleportTarget.position;
                    other.transform.rotation = teleportTarget.rotation;
                    controller.enabled = true; // Reaktiviere den CharacterController
                }
            }
            else
            {
                Debug.LogError("Teleport target is not set.");
            }
        }
    }
}
