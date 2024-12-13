using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform; // Referencia a la cámara principal
    private IMovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<IMovementController>();
    }

    private void Update()
    {
        // Capturar la dirección de entrada y delegar el movimiento y la rotación
        Vector3 movementDirection = GetInputDirection();
        movementController.Move(movementDirection);
        movementController.Rotate(movementDirection);
    }

    private Vector3 GetInputDirection()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return (forward * moveZ + right * moveX).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        interactable?.Interact(this);
    }
}
