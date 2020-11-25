using UnityEngine;

public class CaptainEnemy : Enemy, IDamageable
{

    SpriteRenderer Sprite;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

        if (animstate == 0)
        {
            Sprite.flipX = false;
        }
    }
    public override void Init()
    {
        base.Init();
        Sprite = GetComponent<SpriteRenderer>();
    }
    public override void SkillAction()
    {
        base.SkillAction();
        if (anim.GetCurrentAnimatorStateInfo(1).IsName("Skill"))
        {
            Sprite.flipX = true;
            if (transform.position.x > targetPoint.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.right, Speed * 3 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.left, Speed * 3 * Time.deltaTime);
            }
        }
        else
        {
            Sprite.flipX = false;
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
