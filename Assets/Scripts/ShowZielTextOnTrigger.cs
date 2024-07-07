using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowZielTextOnTrigger : MonoBehaviour
{
    public GameObject textCanvas1;
    public GameObject textCanvas2;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanvas1.SetActive(true);
            textCanvas2.SetActive(true);
            gameManager.StopTimer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanvas1.SetActive(false);
            textCanvas2.SetActive(false);
        }
    }
}
