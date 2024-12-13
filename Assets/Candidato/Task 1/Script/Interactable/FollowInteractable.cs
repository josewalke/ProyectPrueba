using UnityEngine;

public class FollowInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private float followSpeed = 5f; // Velocidad de seguimiento
    [SerializeField] private float minDistance = 2f; // Distancia mínima al jugador
    private Transform playerTransform;              // Referencia al jugador
    private bool isFollowing = false;

    public void Interact(PlayerController player)
    {
        // Activar el seguimiento
        playerTransform = player.transform;
        isFollowing = true;
    }

    private void Update()
    {
        if (isFollowing && playerTransform != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        // Calcular la distancia actual al jugador
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // Si estamos fuera de la distancia mínima, movernos hacia el jugador
        if (distance > minDistance)
        {
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }
}
