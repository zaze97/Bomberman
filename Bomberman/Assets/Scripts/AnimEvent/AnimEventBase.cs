using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventBase : MonoBehaviour
{
    public Animator anim;
    protected void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public virtual void SetJamp()
    {

    }
    }
