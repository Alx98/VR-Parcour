using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbingZoneTrigger : MonoBehaviour
{
    // Komponenten des linken Controllers
    public XRRayInteractor leftRayInteractor;
    public LineRenderer leftLineRenderer;
    public XRInteractorLineVisual leftLineVisual;
    public SortingGroup leftSortingGroup;
    public XRDirectInteractor leftDirectInteractor;

    // Komponenten des rechten Controllers
    public XRRayInteractor rightRayInteractor;
    public LineRenderer rightLineRenderer;
    public XRInteractorLineVisual rightLineVisual;
    public SortingGroup rightSortingGroup;
    public XRDirectInteractor rightDirectInteractor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Jump jumpScript = other.GetComponent<Jump>();
            if (jumpScript != null)
            {
                jumpScript.enabled = false;
            }

            // Deaktiviere den XR Ray Interactor und die zugehörigen Komponenten (linker Controller)
            if (leftRayInteractor != null)
                leftRayInteractor.enabled = false;

            if (leftLineRenderer != null)
                leftLineRenderer.enabled = false;

            if (leftLineVisual != null)
                leftLineVisual.enabled = false;

            if (leftSortingGroup != null)
                leftSortingGroup.enabled = false;

            // Aktiviere den XR Direct Interactor (linker Controller)
            if (leftDirectInteractor != null)
                leftDirectInteractor.enabled = true;

            // Deaktiviere den XR Ray Interactor und die zugehörigen Komponenten (rechter Controller)
            if (rightRayInteractor != null)
                rightRayInteractor.enabled = false;

            if (rightLineRenderer != null)
                rightLineRenderer.enabled = false;

            if (rightLineVisual != null)
                rightLineVisual.enabled = false;

            if (rightSortingGroup != null)
                rightSortingGroup.enabled = false;

            // Aktiviere den XR Direct Interactor (rechter Controller)
            if (rightDirectInteractor != null)
                rightDirectInteractor.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Jump jumpScript = other.GetComponent<Jump>();
            if (jumpScript != null)
            {
                jumpScript.enabled = true;
            }

            // Aktiviere den XR Ray Interactor und die zugehörigen Komponenten (linker Controller)
            if (leftRayInteractor != null)
                Debug.Log("Linker Ray Interactor wurde wieder aktiviert");
                leftRayInteractor.enabled = true;

            if (leftLineRenderer != null)
                leftLineRenderer.enabled = true;

            if (leftLineVisual != null)
                leftLineVisual.enabled = true;

            if (leftSortingGroup != null)
                leftSortingGroup.enabled = true;

            // Deaktiviere den XR Direct Interactor (linker Controller)
            if (leftDirectInteractor != null)
                leftDirectInteractor.enabled = false;

            // Aktiviere den XR Ray Interactor und die zugehörigen Komponenten (rechter Controller)
            if (rightRayInteractor != null)
                rightRayInteractor.enabled = true;

            if (rightLineRenderer != null)
                rightLineRenderer.enabled = true;

            if (rightLineVisual != null)
                rightLineVisual.enabled = true;

            if (rightSortingGroup != null)
                rightSortingGroup.enabled = true;

            // Deaktiviere den XR Direct Interactor (rechter Controller)
            if (rightDirectInteractor != null)
                rightDirectInteractor.enabled = false;
        }
    }
}
