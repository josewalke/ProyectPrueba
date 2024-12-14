using UnityEngine;

public class GuidingState : State
{
    private GuideEnemy enemy;
    private Transform currentCheckpoint;

    public GuidingState(GuideEnemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        Debug.Log("Entrando en estado: Guiding");
        currentCheckpoint = enemy.GetNextCheckpoint();
    }

    public override void Update()
    {
        if (!enemy.IsPlayerInRange())
        {
            enemy.SetStateWithAnnouncement(new ReturningState(enemy));
            return;
        }

        Vector3 flatTarget = new Vector3(
            currentCheckpoint.position.x,
            enemy.transform.position.y,
            currentCheckpoint.position.z
        );

        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            flatTarget,
            enemy.patrolSpeed * Time.deltaTime
        );

        if (Vector3.Distance(enemy.transform.position, flatTarget) < 0.5f)
        {
            currentCheckpoint = enemy.GetNextCheckpoint();
        }
    }

    public override void Exit()
    {
        Debug.Log("Saliendo de estado: Guiding");
    }
}
