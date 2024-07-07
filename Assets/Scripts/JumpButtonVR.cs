using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class JumpButtonVR : MonoBehaviour
{

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameManager gameManager;
    public GameObject player; // Referenz zum Spieler
    public float jumpForce = 100f; // Stärke der Sprungkraft

    private Jump jumpScript;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        originalPosition = button.transform.localPosition;

        // Suche das Jump-Skript auf dem Player-GameObject
        if (player != null)
        {
            jumpScript = player.GetComponent<Jump>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed) 
        {
            
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            //Spieler in die Luft werfen
            if (other.gameObject == player && jumpScript != null)
            {
                Debug.Log("Spieler erkannt: " + player.name);
                jumpScript.PerformJump(jumpForce);
            }
            button.transform.localPosition = new Vector3(0, 0.65f, 0);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed && other.gameObject == presser)
        {
            button.transform.localPosition = originalPosition;
            onRelease.Invoke();
            isPressed = false;
        }
        
    }

}
