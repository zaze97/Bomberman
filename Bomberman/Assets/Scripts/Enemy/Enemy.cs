using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 当前的状态
    /// </summary>
    EnemyBaseState currentStart;

    [Header("移动")]
    public float Speed;

    public Transform PointA, PointB;
    public Transform targetPoint;

    public List<Transform> attackList = new List<Transform>();//存放可以攻击的物体
    /// <summary>
    /// 巡逻状态
    /// </summary>
    public PatrolState patrolState = new PatrolState();
    void Start()
    {
        TransformToState(patrolState);
    }


    void Update()
    {
        currentStart.OnUpdate(this);

    }

    public void TransformToState(EnemyBaseState State)
    {
        currentStart = State;
        currentStart.EnterStart(this);
    }

    /// <summary>
    /// 移动
    /// </summary>
    public void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPoint.position,Speed*Time.deltaTime);
        FilpDirection();
    }
    /// <summary>
    /// 攻击玩家
    /// </summary>
    public virtual void AttackAction()
    {

    }
    /// <summary>
    /// 对炸弹使用技能
    /// </summary>
    public virtual void SkillAction()
    {

    }
    /// <summary>
    /// 翻转物体方向
    /// </summary>
    public void FilpDirection()
    {
        if (transform.position.x < targetPoint.position.x)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f,0f, 0f);
    }
    /// <summary>
    /// 切换目标状态
    /// </summary>
    public void SwitchPoint()
    {
        if (Mathf.Abs(PointA.position.x - transform.position.x) > Mathf.Abs(PointB.position.x - transform.position.x))
        {
            targetPoint = PointA;
        }
        else
        {
            targetPoint = PointB;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!attackList.Contains(collision.transform))
        attackList.Add(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attackList.Remove(collision.transform);
    }
}
