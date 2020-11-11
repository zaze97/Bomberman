using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 当前的状态
    /// </summary>
    EnemyBaseState currentStart;

    public Animator anim;
    public int animstate;
    [Header("敌人状态")]
    public float health;
    public bool isDead;

    [Header("移动")]
    public float Speed;

    public Transform PointA, PointB;
    public Transform targetPoint;

    [Header("攻击")]
    public float nextAttack = 0;
    public float attackRate;//攻击的时间间隔
    public float attackRange, skillRange;//普通攻击距离和技能攻击距离

    /// <summary>
    /// 警告标示
    /// </summary>
    private GameObject alarmsign;

    public List<Transform> attackList = new List<Transform>();//存放可以攻击的物体

    /// <summary>
    /// 巡逻状态
    /// </summary>
    public PatrolState patrolState = new PatrolState();
    /// <summary>
    /// 攻击状态
    /// </summary>
    public AttackState aAttackState = new AttackState();
    public virtual void Init()//初始化
    {
        anim = GetComponent<Animator>();
        alarmsign = transform.GetChild(0).gameObject;
    }

    private void Awake()
    {
        Init();
    }

    protected void Start()
    {
        TransformToState(patrolState);
    }


    void Update()
    {
        anim.SetBool("dead", isDead);
        if (isDead)
            return;
        currentStart.OnUpdate(this);
        anim.SetInteger("state", animstate);


    }
    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="State"></param>
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
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, Speed * Time.deltaTime);
        FilpDirection();
    }
    /// <summary>
    /// 攻击玩家
    /// </summary>
    public void AttackAction()
    {
        if (Vector2.Distance(transform.position, targetPoint.position) < attackRange)
        {
            if (Time.time > nextAttack)
            {
                anim.SetTrigger("attack");
                Debug.Log("普通攻击");
                nextAttack = Time.time + attackRate;
            }
        }
    }
    /// <summary>
    /// 对炸弹使用技能
    /// </summary>
    public virtual void SkillAction()
    {
        if (Vector2.Distance(transform.position, targetPoint.position) < skillRange)
        {
            if (Time.time > nextAttack)
            {
                anim.SetTrigger("skill");
                Debug.Log("技能攻击");
                nextAttack = Time.time + attackRate;
            }
        }
    }
    /// <summary>
    /// 翻转物体方向
    /// </summary>
    public void FilpDirection()
    {
        if (transform.position.x < targetPoint.position.x)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    /// <summary>
    /// 切换目标巡逻点位
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
        if (!attackList.Contains(collision.transform))
            attackList.Add(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attackList.Remove(collision.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Worring());
    }

    IEnumerator Worring()
    {
        alarmsign.SetActive(true);
        yield return new WaitForSeconds(alarmsign.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
        alarmsign.SetActive(false);
    }
}
