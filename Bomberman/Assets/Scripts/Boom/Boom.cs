using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private Animator m_anim;
    private Collider2D coll;
    private Rigidbody2D rb;
    public float startTime;
    public float waitTime;

    [Header("范围")]
    public float radius=1.33f;
    public float bombForce;//炸弹威力
    public LayerMask targetMask;
    void Start()
    {
        m_anim = this.GetComponent<Animator>();
        coll = this.GetComponent<Collider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        startTime = Time.time;
        ///绑定帧事件
        AnimatorEvent.AddAnimationEvent(m_anim, "BoomExplotion", 0.02f, "Explotion");
        AnimatorEvent.AddAnimationEvent(m_anim, "BoomExplotion", 0.09f, "DestoryThis");
    }
    void Update()
    {
        if (!m_anim.GetCurrentAnimatorStateInfo(0).IsName("BoomOff"))
        {
            if (Time.time > startTime + waitTime)
            {
                m_anim.Play("BoomExplotion");
            }
        }
    }
    public void Explotion()//animEvent
    {
        coll.enabled = false;
        Collider2D[] aroundObjects = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);//获取炸弹周围的物体
        rb.gravityScale = 0;//重力更改为0
        foreach (var item in aroundObjects)
        {
            Vector3 pos = transform.position - item.transform.position;

            item.GetComponent<Rigidbody2D>().AddForce(-pos+Vector3.up* bombForce,ForceMode2D.Impulse);//给他一个力,ForceMode2D.Impulse冲击力
            Debug.Log(item.tag );
            if (item.CompareTag("Boom")&& item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BoomOff"))
            {
                item.GetComponent<Boom>().TurnOn();
            }
            if (item.CompareTag("Player"))
            {
                item.GetComponent<IDamageable>().GetHit(3);
            }
            if (item.CompareTag("Enemy"))
            {
                item.GetComponent<IDamageable>().GetHit(3);
            }
        }
    }

    public void DestoryThis()
    {
        Destroy(this.gameObject);
    }

    public void TurnOff()
    {
        m_anim.Play("BoomOff");
        gameObject.layer = LayerMask.NameToLayer("NPC");
    }

    public void TurnOn()
    {
        startTime = Time.time;
        m_anim.Play("Boom");
        gameObject.layer = LayerMask.NameToLayer("Boom");
    }


    /// <summary>
    /// 画出圆
    /// </summary>
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
