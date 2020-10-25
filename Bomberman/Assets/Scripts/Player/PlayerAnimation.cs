using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public PlayerControll PlayerControll;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb=this.GetComponent<Rigidbody2D>();
        PlayerControll = this.GetComponent<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("jump", PlayerControll.isjump);
        anim.SetBool("ground", PlayerControll.isGround);
    }
}
