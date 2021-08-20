using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFXAnimEvent : AnimEventBase
{
#pragma warning disable CS0108 // 成员隐藏继承的成员；缺少关键字 new
    protected void Start()
#pragma warning restore CS0108 // 成员隐藏继承的成员；缺少关键字 new
    {
        base.Start();
        AnimatorEvent.AddAnimationEvent(anim, "JumpFx", 0.05f, "SetJamp");
    }
    public override void SetJamp()
    {
        gameObject.SetActive(false);
    }
}
