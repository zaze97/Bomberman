using UnityEngine;

public class AttackState : EnemyBaseState
{
    public override void EnterStart(Enemy enemy)
    {
        Debug.Log("发现敌人");
        enemy.animstate = 2;
        enemy.targetPoint = enemy.attackList[0];
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (enemy.attackList.Count == 0)
        {
            enemy.TransformToState(enemy.patrolState);
        }
        else if (enemy.attackList.Count > 1)//循环遍历数组中哪个最近
        {
            for (int i = 0; i < enemy.attackList.Count; i++)
            {
                if(Mathf.Abs(enemy.transform.position.x-enemy.attackList[i].position.x)< 
                    Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x))
                {
                    enemy.targetPoint = enemy.attackList[i];
                }
            }
        }
        else
        {
            enemy.targetPoint= enemy.attackList[0];
        }

        if (enemy.targetPoint.CompareTag("Player"))//他的标签是什么
            enemy.AttackAction();
        if (enemy.targetPoint.CompareTag("Boom"))
            enemy.SkillAction();

        enemy.MoveToTarget();
    }
}
