public class CucmberEnemy : Enemy
{
#pragma warning disable CS0108 // 成员隐藏继承的成员；缺少关键字 new
    protected void Start()
#pragma warning restore CS0108 // 成员隐藏继承的成员；缺少关键字 new
    {
        base.Start();
        AnimatorEvent.AddAnimationEvent(anim, "Blowthewick", 0.08f, "SetOff");
    }
    public void SetOff()//AnimationEvent
    {
        targetPoint.GetComponent<Boom>().TurnOff();
    }
}
