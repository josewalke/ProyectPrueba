using UnityEngine;

public class DeactivateInteractable : MonoBehaviour, IInteractable
{
    public void Interact(PlayerController player)
    {
        gameObject.SetActive(false);
    }
}
