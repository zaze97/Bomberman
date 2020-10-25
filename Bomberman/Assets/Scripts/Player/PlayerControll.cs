using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    Rigidbody2D rb;
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
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
    }
    private void FixedUpdate()//使用物理引擎使用FixUpdate
    {
        PhysicsCheck();
        Movement();
        Jump();
    }
    void CheckInput()
    {
        if (Input.GetButtonDown("Jump")&&isGround)
        {
            cabJump = true;
        }
    }
    void Movement()//移动
    {
        //float horizontalInput = Input.GetAxis("Horizontal");//缓慢移动（包含小数）
        float horizontalInput = Input.GetAxisRaw("Horizontal");//缓慢移动（不包含小数）
        rb.velocity = new Vector2(horizontalInput*speed,rb.velocity.y);//进行移动

        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput,1,1);
        }

    }

    void Jump()//跳跃
    {
        if (cabJump)
        {
            isjump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            cabJump = false;
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
}
