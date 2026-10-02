using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    public bool isLocked = false;
    public string lockedMessage = "It's locked.";

    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D doorCollider;

    public string Prompt => isLocked ? lockedMessage : (isOpen ? "Close" : "Open");

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();
    }

    public void Interact()
    {
        if (isLocked)
        {
            Debug.Log(lockedMessage);
            return;
        }

        isOpen = !isOpen;

        // Simple visual feedback for now: fade the sprite and disable collision when open
        if (spriteRenderer != null)
            spriteRenderer.color = isOpen ? new Color(1, 1, 1, 0.3f) : Color.white;

        if (doorCollider != null)
            doorCollider.enabled = !isOpen;

        Debug.Log(isOpen ? "Door opened" : "Door closed");
    }
}