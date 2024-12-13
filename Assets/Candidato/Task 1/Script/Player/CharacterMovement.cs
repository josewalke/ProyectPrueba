using UnityEngine;

public class CharacterMovement : MonoBehaviour, IMovementController
{
    public float speed = 5f;          // Velocidad de movimiento
    public float rotationSpeed = 10f; // Velocidad de rotación del personaje

    public void Move(Vector3 direction)
    {
        // Mover al personaje
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    public void Rotate(Vector3 direction)
    {
        // Rotar el personaje hacia la dirección del movimiento
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
