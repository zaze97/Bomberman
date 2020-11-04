using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : AnimEventBase
{
    private PlayerControl PlayerControl;
#pragma warning disable CS0108 // 成员隐藏继承的成员；缺少关键字 new
    protected void Start()
#pragma warning restore CS0108 // 成员隐藏继承的成员；缺少关键字 new
    {
        base.Start();
        PlayerControl = this.GetComponent<PlayerControl>();
        AnimatorEvent.AddAnimationEvent(anim, "player_ground", 0.00f, "SetJamp");
    }
    public override void SetJamp()
    {
        PlayerControl.LandFx.transform.position = transform.position + new Vector3(0, -0.74f, 0);
        PlayerControl.LandFx.SetActive(true);
    }
}

