using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandFXAnimEvent : AnimEventBase
{
    protected void Start()
    {
        base.Start();
        AnimatorEvent.AddAnimationEvent(anim, "LandFx", 0.05f, "SetJamp");
    }
    public override void SetJamp()
    {
        gameObject.SetActive(false);
    }
}
