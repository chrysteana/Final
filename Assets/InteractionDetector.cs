using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Make sure this is included for input handling

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null;
    public GameObject interactionIcon;

    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions(); // Initialize input actions
    }

    void OnEnable()
    {
        inputActions.Enable();  // Enable input actions
        inputActions.Gameplay.Interact.performed += OnInteract; // Subscribe to interact event
    }

    void OnDisable()
    {
        inputActions.Gameplay.Interact.performed -= OnInteract; // Unsubscribe to prevent memory leaks
        inputActions.Disable();
    }

    // This will be called when the player presses the "E" key
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && interactableInRange != null)
        {
            interactableInRange.Interact();  // Call the Interact method on the NPC
        }
    }

    void Start()
    {
        interactionIcon.SetActive(false); // Hide the interaction icon at the start
    }

    void OnTriggerEnter2D(Collider2D collision) // Make sure this is 2D collider
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;  // Set the interactable in range
            interactionIcon.SetActive(true);  // Show the interaction icon
        }
    }

    void OnTriggerExit2D(Collider2D collision) // Make sure this is 2D collider
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;  // Clear the interactable
            interactionIcon.SetActive(false);  // Hide the interaction icon
        }
    }
}
