using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractorSwitcher : MonoBehaviour
{
    public GameObject directInteractor;
    public GameObject rayInteractor;
    public InputHelpers.Button switchButton = InputHelpers.Button.MenuButton; // Der Knopf zum Umschalten
    public float activationThreshold = 0.1f; // Schwelle, ab der der Knopf als gedrückt gilt

    private XRController controller; // Der Controller, der den Umschaltknopf hat
    private bool isDirectActive = true;

    void Start()
    {
        // Versuche, den XRController im gesamten Hierarchie-Objekt zu finden
        controller = GetComponentInChildren<XRController>();

        if (controller == null)
        {
            Debug.LogError("XRController not found in the children of the GameObject.");
            return;
        }

        // Initiale Zustände festlegen
        SetInteractorState(isDirectActive);
    }

    void Update()
    {
        if (controller != null)
        {
            // Überprüfe, ob der Umschaltknopf gedrückt wurde
            if (InputHelpers.IsPressed(controller.inputDevice, switchButton, out bool isPressed, activationThreshold) && isPressed)
            {
                isDirectActive = !isDirectActive;
                SetInteractorState(isDirectActive);
            }
        }
    }

    private void SetInteractorState(bool directActive)
    {
        directInteractor.SetActive(directActive);
        rayInteractor.SetActive(!directActive);
    }
}
