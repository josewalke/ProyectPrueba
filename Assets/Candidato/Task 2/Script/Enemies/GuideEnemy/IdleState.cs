using UnityEngine;

public class IdleState : State
{
    private GuideEnemy enemy;

    public IdleState(GuideEnemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        Debug.Log("Entrando en estado: Idle");
    }

    public override void Update()
    {
        if (enemy.IsPlayerInRange())
        {
            enemy.SetStateWithAnnouncement(new GuidingState(enemy));
        }
    }

    public override void Exit()
    {
        Debug.Log("Saliendo de estado: Idle");
    }
}
