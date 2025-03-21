﻿using UnityEngine;

public class PlayerControl : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    PlayerAnimation playerain;
    [Header("玩家状态")]
    public float health;
    public bool isDead;


    public float speed;//速度
    public float jumpForce;//跳跃速度



    [Header("是否在地面")]
    public bool isGround;
    public bool cabJump;//是否被按下跳跃键

    public bool isjump;
    [Header("检测点")]
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    [Header("特效")]
    public GameObject JumpFx;
    public GameObject LandFx;

    [Header("攻击")]
    public GameObject BoomPrefab;
    public float nextAttack = 0;
    public float attackrote;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerain = this.GetComponent<PlayerAnimation>();
        health = GameManager.instance.LoadHealth();
        UIManager.instance.UpdateHealth(health);
        GameManager.instance.IsPlayer(this);
    }

    void Update()
    {
        if (isDead)
            return;
        CheckInput();
    }
    private void FixedUpdate()//使用物理引擎使用FixUpdate
    {
        if (isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }
            
        PhysicsCheck();
        Movement();
        Jump();
    }
    void CheckInput()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            cabJump = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }
    void Movement()//移动
    {
        //float horizontalInput = Input.GetAxis("Horizontal");//缓慢移动（包含小数）
        float horizontalInput = Input.GetAxisRaw("Horizontal");//缓慢移动（不包含小数）
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);//进行移动

        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput, 1, 1);
        }
        //通过旋转
        //if (horizontalInput > 0)
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //else
        //    transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void Jump()//跳跃
    {
        if (cabJump)
        {
            isjump = true;
            JumpFx.SetActive(true);
            JumpFx.transform.position = transform.position + new Vector3(0, -0.58f, 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            cabJump = false;
        }
    }
    /// <summary>
    /// 攻击
    /// </summary>
    public void Attack()
    {
        if (Time.time > nextAttack)
        {
            Instantiate(BoomPrefab, transform.position, BoomPrefab.transform.rotation);
            nextAttack = Time.time + attackrote;
        }
    }

    /// <summary>
    /// 物理检测是否在地面
    /// </summary>
    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            isjump = false;
            rb.gravityScale = 1;
        }
    }
    /// <summary>
    /// 画出圆
    /// </summary>
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, checkRadius);
    }

    public void GetHit(float damage)
    {
        if (!playerain.GetAnim().GetCurrentAnimatorStateInfo(1).IsName("player_hit")){
            health -= damage;
            UIManager.instance.UpdateHealth(health);
            playerain.GetHit();
            if (health < 1)
            {
                health = 0;
                isDead = true;
            }
        }
    }
}
