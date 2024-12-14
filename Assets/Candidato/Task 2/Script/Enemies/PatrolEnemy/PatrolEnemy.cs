using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] checkpoints; // Checkpoints de patrulla
    public Transform player;        // Referencia al jugador
    public float detectionRange = 4f; // Rango de detecci�n
    public float patrolSpeed = 3f;    // Velocidad de patrulla

    private StateMachine stateMachine;
    private int currentCheckpoint = 0; // �ndice del checkpoint actual

    public StateMachine StateMachine => stateMachine; // Propiedad p�blica para acceder al stateMachine

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

    private void OnDrawGizmosSelected()
    {
        if (checkpoints == null) return;

        Gizmos.color = Color.yellow;
        foreach (Transform checkpoint in checkpoints)
        {
            // Dibuja una l�nea desde el enemigo al checkpoint proyectado
            Vector3 flatCheckpoint = new Vector3(checkpoint.position.x, transform.position.y, checkpoint.position.z);
            Gizmos.DrawLine(transform.position, flatCheckpoint);
            Gizmos.DrawSphere(flatCheckpoint, 0.3f);
        }

        // Cambiar el color de los Gizmos
        Gizmos.color = Color.red;
        // Dibujar un c�rculo en el plano XZ para mostrar el rango de detecci�n
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
