using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomContinuousMoveProvider : ActionBasedContinuousMoveProvider
{
    public float sprintSpeed = 6.0f; // Geschwindigkeit beim Sprinten
    public InputActionProperty sprintAction; // Die Aktion zum Sprinten

    protected override Vector2 ReadInput()
    {
        Vector2 input = base.ReadInput();

        // Überprüfe, ob die Sprint-Taste gedrückt ist
        if (sprintAction.action != null && sprintAction.action.ReadValue<float>() > 0.5f)
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = 2.0f; // Setze hier die normale Gehgeschwindigkeit
        }

        return input;
    }
}
