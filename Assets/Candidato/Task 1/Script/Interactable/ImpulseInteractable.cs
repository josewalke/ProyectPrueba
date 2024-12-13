using UnityEngine;

public class ImpulseInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float impulseForce = 10f; // Magnitud del impulso, configurable desde el Inspector

    public void Interact(PlayerController player)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calcula la dirección del impulso desde el jugador hacia el objeto
            Vector3 impulse = (transform.position - player.transform.position).normalized * impulseForce;
            rb.AddForce(impulse, ForceMode.Impulse);
        }
    }

    // Método opcional para cambiar el impulso dinámicamente desde otros scripts
    public void SetImpulseForce(float newForce)
    {
        impulseForce = newForce;
    }
}
