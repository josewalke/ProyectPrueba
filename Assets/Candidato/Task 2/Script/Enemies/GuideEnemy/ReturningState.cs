using UnityEngine;

public class ReturningState : State
{
    private GuideEnemy enemy;
    private float timer;

    public ReturningState(GuideEnemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        Debug.Log("Entrando en estado: Returning");
        timer = 0f;
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= enemy.waitTime)
        {
            Vector3 flatTarget = new Vector3(
                enemy.GetOriginalPosition().x,
                enemy.transform.position.y,
                enemy.GetOriginalPosition().z
            );

            enemy.transform.position = Vector3.MoveTowards(
                enemy.transform.position,
                flatTarget,
                enemy.patrolSpeed * Time.deltaTime
            );

            if (Vector3.Distance(enemy.transform.position, flatTarget) < 0.5f)
            {
                enemy.SetStateWithAnnouncement(new IdleState(enemy));
            }
        }
    }

    public override void Exit()
    {
        Debug.Log("Saliendo de estado: Returning");
    }
}
