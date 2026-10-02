using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Settings")]
    public float interactRange = 1.2f;
    public LayerMask interactableLayer;

    private IInteractable currentInteractable;

    void Update()
    {
        DetectInteractable();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    void DetectInteractable()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRange, interactableLayer);

        if (hit != null && hit.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            currentInteractable = interactable;
        }
        else
        {
            currentInteractable = null;
        }
    }

    // Optional: visualize the range in the Scene view while selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}