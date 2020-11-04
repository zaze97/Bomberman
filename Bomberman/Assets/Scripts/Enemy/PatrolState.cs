using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 巡逻状态
/// </summary>
public class PatrolState : EnemyBaseState
{
    public override void EnterStart(Enemy enemy)
    {
        enemy.SwitchPoint();
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.01f)
            enemy.SwitchPoint();

        enemy.MoveToTarget();
    }
}
