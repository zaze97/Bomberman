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
        enemy.animstate = 0;//改变动画状态机参数
        enemy.SwitchPoint();
    }

    public override void OnUpdate(Enemy enemy)
    {
        if (!enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        { //动画是否正在播放

            enemy.animstate = 1;//改变动画状态机参数
            enemy.MoveToTarget();
        }


        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.01f)
        {//是否到达巡逻点

            enemy.TransformToState(enemy.patrolState);

        }

        if (enemy.attackList.Count > 0)
            enemy.TransformToState(enemy.aAttackState);

    }
}
