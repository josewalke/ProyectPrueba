using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;            // El objeto al que la cámara sigue (Player)
    public Vector3 offset = new Vector3(0, 5, -10); // Distancia fija de la cámara al jugador
    public float rotationSpeed = 5f;    // Velocidad de rotación

    private void LateUpdate()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        // Rotación manual utilizando el input del ratón
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalInput = -Input.GetAxis("Mouse Y") * rotationSpeed;

        // Rotar alrededor del objetivo
        Quaternion horizontalRotation = Quaternion.AngleAxis(horizontalInput, Vector3.up);
        Quaternion verticalRotation = Quaternion.AngleAxis(verticalInput, transform.right);

        // Actualizar el offset con la rotación acumulada
        offset = horizontalRotation * verticalRotation * offset;

        // Limitar inclinación vertical
        offset.y = Mathf.Clamp(offset.y, 2f, 10f);

        // Establecer la posición de la cámara y que mire al objetivo
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
