public class WhaleEnemy : Enemy, IDamageable
{
    public float scale;
    protected override void Start()
    {
        base.Start();
        AnimatorEvent.AddAnimationEvent(anim, "Swalow(Bomb)", 0.08f, "Swalow");
    }
    public void Swalow()//AnimationEvent
    {
        targetPoint.GetComponent<Boom>().TurnOff();
        targetPoint.gameObject.SetActive(false);
        transform.localScale = scale * transform.localScale;
        skillRange += 0.4f;
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
