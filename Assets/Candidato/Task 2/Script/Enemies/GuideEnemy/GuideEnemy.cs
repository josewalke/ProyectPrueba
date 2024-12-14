using UnityEngine;

public class GuideEnemy : MonoBehaviour
{
    public Transform[] checkpoints;  // Checkpoints de guía
    public Transform player;         // Referencia al jugador
    public float detectionRange = 2f; // Rango de detección
    public float patrolSpeed = 3f;    // Velocidad de movimiento
    public float waitTime = 10f;      // Tiempo de espera antes de regresar al inicio

    private Vector3 originalPosition;
    private StateMachine stateMachine;
    private int currentCheckpoint = 0; // Índice del checkpoint actual

    public StateMachine StateMachine => stateMachine; // Propiedad pública para acceder al stateMachine

    // Propiedad pública para mostrar el estado actual en el Inspector
    public string CurrentStateName => stateMachine.CurrentState?.GetType().Name ?? "None";

    private void Awake()
    {
        stateMachine = new StateMachine();
        originalPosition = transform.position; // Guardar la posición inicial
    }

    private void Start()
    {
        SetStateWithAnnouncement(new IdleState(this)); // Comenzar en el estado de espera
    }

    private void Update()
    {
        stateMachine.Update(); // Actualizar la máquina de estados
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
        Debug.Log($"GuideEnemy cambió al estado: {newState.GetType().Name}");
        stateMachine.SetState(newState);
    }

    // Dibujar Gizmos para el rango de detección, la posición inicial y los checkpoints
    private void OnDrawGizmosSelected()
    {
        // Dibujar el rango de detección
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Dibujar la posición original
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

                    // Dibuja una línea hacia el siguiente checkpoint
                    if (i < checkpoints.Length - 1)
                    {
                        Gizmos.DrawLine(checkpoint.position, checkpoints[i + 1].position);
                    }
                }
            }

            // Conectar el último checkpoint con el primero para cerrar el ciclo
            Gizmos.DrawLine(checkpoints[checkpoints.Length - 1].position, checkpoints[0].position);
        }
    }
}
