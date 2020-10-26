using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFXAnimEvent : AnimEventBase
{
    protected void Start()
    {
        base.Start();
        AnimatorEvent.AddAnimationEvent(anim, "JumpFx", 0.05f, "SetJamp");
    }
    public override void SetJamp()
    {
        gameObject.SetActive(false);
    }
}
