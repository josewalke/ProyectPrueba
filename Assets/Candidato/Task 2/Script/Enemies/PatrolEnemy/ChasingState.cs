using UnityEngine;

public class ChasingState : State
{
    private PatrolEnemy enemy;

    public ChasingState(PatrolEnemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        // Configuración inicial
    }

    public override void Update()
    {
        if (!enemy.IsPlayerInRange())
        {
            enemy.StateMachine.SetState(new PatrollingState(enemy));
            return;
        }

        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            enemy.player.position,
            enemy.patrolSpeed * Time.deltaTime
        );
    }

    public override void Exit()
    {
        // Limpieza al salir del estado
    }
}
