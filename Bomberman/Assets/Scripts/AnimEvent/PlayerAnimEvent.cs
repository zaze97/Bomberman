using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : AnimEventBase
{
    private PlayerControl PlayerControl;
    protected void Start()
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

