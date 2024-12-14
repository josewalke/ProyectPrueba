using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] checkpoints; // Checkpoints de patrulla
    public Transform player;        // Referencia al jugador
    public float detectionRange = 4f; // Rango de detección
    public float patrolSpeed = 3f;    // Velocidad de patrulla

    private StateMachine stateMachine;
    private int currentCheckpoint = 0; // Índice del checkpoint actual

    public StateMachine StateMachine => stateMachine; // Propiedad pública para acceder al stateMachine

    private void Awake()
    {
        stateMachine = new StateMachine();
    }

    private void Start()
    {
        stateMachine.SetState(new PatrollingState(this));
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

    private void OnDrawGizmosSelected()
    {
        if (checkpoints == null) return;

        Gizmos.color = Color.yellow;
        foreach (Transform checkpoint in checkpoints)
        {
            // Dibuja una línea desde el enemigo al checkpoint proyectado
            Vector3 flatCheckpoint = new Vector3(checkpoint.position.x, transform.position.y, checkpoint.position.z);
            Gizmos.DrawLine(transform.position, flatCheckpoint);
            Gizmos.DrawSphere(flatCheckpoint, 0.3f);
        }

        // Cambiar el color de los Gizmos
        Gizmos.color = Color.red;
        // Dibujar un círculo en el plano XZ para mostrar el rango de detección
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
