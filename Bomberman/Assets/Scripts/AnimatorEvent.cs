using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorEvent
{
    /// <summary>
    /// 给动画上添加帧事件
    /// </summary>
    /// <param name="animator">动画组件</param>
    /// <param name="anim">动画的名字</param>
    /// <param name="animtime">插入事件的帧数</param>
   /// <param name="EventName">事件的名字</param>
    /// <param name="stringParameter">事件的参数</param>
    public static void AddAnimationEvent(Animator animator,string anim,float animtime, string EventName, string stringParameter=null)
    {
        //获取动画组件中所有动画
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        for (int i = 0; i < clips.Length; i++)
        {
            //根据动画名字  找到你要添加的动画
            if (string.Equals(clips[i].name, anim))
            {
                //添加动画事件
                AnimationEvent events = new AnimationEvent();

                //添加第一个事件  带参数
                events.functionName = EventName;
                events.time = animtime;
                if(stringParameter!=null)
                events.stringParameter = stringParameter;
                clips[i].AddEvent(events);
            }
        }
        animator.Rebind();
    }

    public static T FindChild<T>(this Transform trans, string name)
    {
        Transform child = null;
        Transform[] children = trans.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name.Equals(name))
            {
                child = children[i];
                break;
            }
        }
        if (child != null)
        {
            return child.GetComponent<T>();
        }
        else
        {
            Debug.Log("未找到指定的组件，指定的组件为：" + typeof(T).FullName + "-----" + trans);
            return default(T);
        }
    }

    //private void event_0(string parma)
    //{
    //    Debug.Log("第一个事件:" + parma);
    //}

    //private void event_1()
    //{
    //    Debug.Log("第二个事件");
    //}
}
