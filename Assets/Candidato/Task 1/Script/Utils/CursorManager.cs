using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool isCursorLocked = false; // Estado actual del cursor

    private void Start()
    {
        LockCursor(); // Inicia el juego con el cursor bloqueado
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor(); // Desbloquea el cursor al presionar Escape
        }
        else if (Input.GetMouseButtonDown(0) && !isCursorLocked)
        {
            LockCursor(); // Bloquea el cursor al hacer clic izquierdo si no está bloqueado
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false;                  // Oculta el cursor
        isCursorLocked = true;                   // Actualiza el estado
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;  // Libera el cursor
        Cursor.visible = true;                   // Hace visible el cursor
        isCursorLocked = false;                  // Actualiza el estado
    }
}
