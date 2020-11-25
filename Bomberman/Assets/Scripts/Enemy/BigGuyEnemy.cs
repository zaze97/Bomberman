using UnityEngine;

public class BigGuyEnemy : Enemy, IDamageable
{
    public Transform pickupPoint;

    //力的变量
    public float power;

    protected override void Start()
    {
        base.Start();
        AnimatorEvent.AddAnimationEvent(anim, "Pick(Bomb)", 0.04f, "PickUpBomb");
        AnimatorEvent.AddAnimationEvent(anim, "Throw(Bomb)", 0.03f, "ThrowAway");
    }
    /// <summary>
    /// 捡起炸弹
    /// </summary>
    public void PickUpBomb()//AnimationEvent
    {
        if (targetPoint.CompareTag("Boom")&&!hasbomb)
        {
            targetPoint.gameObject.transform.position = pickupPoint.position;
            targetPoint.SetParent(pickupPoint);
            targetPoint.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            hasbomb = true;
        }
    }
    /// <summary>
    /// 扔出炸弹
    /// </summary>
    public void ThrowAway()//AnimationEvent
    {
        if (hasbomb)
        {
            targetPoint.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            targetPoint.SetParent(transform.parent.parent);

            if (FindObjectOfType<PlayerControl>().gameObject.transform.position.x - transform.position.x < 0)//找到有这个组件的物体
                targetPoint.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * power, ForceMode2D.Impulse);
            else
            {
                targetPoint.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * power, ForceMode2D.Impulse);
            }
            hasbomb = false;
        }
    }
    public void GetHit(float damage)
    {

        health -= damage;
        anim.SetTrigger("hit");
        if (health < 1)
        {
            health = 0;
            isDead = true;
        }
    }
}
