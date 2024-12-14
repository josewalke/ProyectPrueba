using UnityEngine;

public class GuideEnemy : MonoBehaviour
{
    public Transform[] checkpoints;  // Checkpoints de gu�a
    public Transform player;         // Referencia al jugador
    public float detectionRange = 2f; // Rango de detecci�n
    public float patrolSpeed = 3f;    // Velocidad de movimiento
    public float waitTime = 10f;      // Tiempo de espera antes de regresar al inicio

    private Vector3 originalPosition;
    private StateMachine stateMachine;
    private int currentCheckpoint = 0; // �ndice del checkpoint actual

    public StateMachine StateMachine => stateMachine; // Propiedad p�blica para acceder al stateMachine

    // Propiedad p�blica para mostrar el estado actual en el Inspector
    public string CurrentStateName => stateMachine.CurrentState?.GetType().Name ?? "None";

    private void Awake()
    {
        stateMachine = new StateMachine();
        originalPosition = transform.position; // Guardar la posici�n inicial
    }

    private void Start()
    {
        SetStateWithAnnouncement(new IdleState(this)); // Comenzar en el estado de espera
    }

    private void Update()
    {
        stateMachine.Update(); // Actualizar la m�quina de estados
    }

    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }

    public Transform GetNextCheckpoint()
    {
        Transform checkpoint = checkpoints[currentCheckpoint];
        currentCheckpoint = (currentCheckpoint + 1) % checkpoints.Length;
        return checkpoint;
    }

    public Vector3 GetOriginalPosition()
    {
        return originalPosition;
    }

    // Cambiar estado y anunciarlo
    public void SetStateWithAnnouncement(State newState)
    {
        Debug.Log($"GuideEnemy cambi� al estado: {newState.GetType().Name}");
        stateMachine.SetState(newState);
    }

    // Dibujar Gizmos para el rango de detecci�n, la posici�n inicial y los checkpoints
    private void OnDrawGizmosSelected()
    {
        // Dibujar el rango de detecci�n
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Dibujar la posici�n original
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(originalPosition, 0.2f);

        // Dibujar los checkpoints
        if (checkpoints != null && checkpoints.Length > 0)
        {
            Gizmos.color = Color.yellow;

            for (int i = 0; i < checkpoints.Length; i++)
            {
                Transform checkpoint = checkpoints[i];
                if (checkpoint != null)
                {
                    // Dibuja una esfera en cada checkpoint
                    Gizmos.DrawSphere(checkpoint.position, 0.2f);

                    // Dibuja una l�nea hacia el siguiente checkpoint
                    if (i < checkpoints.Length - 1)
                    {
                        Gizmos.DrawLine(checkpoint.position, checkpoints[i + 1].position);
                    }
                }
            }

            // Conectar el �ltimo checkpoint con el primero para cerrar el ciclo
            Gizmos.DrawLine(checkpoints[checkpoints.Length - 1].position, checkpoints[0].position);
        }
    }
}
