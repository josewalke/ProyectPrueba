using UnityEngine;

public class PatrollingState : State
{
    private PatrolEnemy enemy;
    private Transform currentCheckpoint;

    public PatrollingState(PatrolEnemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        currentCheckpoint = enemy.GetNextCheckpoint();
    }

    public override void Update()
    {
        if (enemy.IsPlayerInRange())
        {
            enemy.StateMachine.SetState(new ChasingState(enemy));
            return;
        }

        // Ajustar la posición del checkpoint al mismo plano que el enemigo
        Vector3 flatTargetPosition = new Vector3(
            currentCheckpoint.position.x,
            enemy.transform.position.y, // Mantener la altura del enemigo
            currentCheckpoint.position.z
        );

        // Movimiento hacia el checkpoint ajustado
        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            flatTargetPosition,
            enemy.patrolSpeed * Time.deltaTime
        );

        // Verificar si se alcanzó el checkpoint
        if (Vector3.Distance(enemy.transform.position, flatTargetPosition) < 0.5f)
        {
            currentCheckpoint = enemy.GetNextCheckpoint();
        }
    }

    public override void Exit()
    {
        // No es necesario realizar limpieza
    }
}
