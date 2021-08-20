public class CucmberEnemy : Enemy, IDamageable
{

    protected override void Start()

    {
        base.Start();
        AnimatorEvent.AddAnimationEvent(anim, "Skill", 0.08f, "SetOff");
    }
    public void SetOff()//AnimationEvent
    {
        targetPoint.GetComponent<Boom>().TurnOff();
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
