using System;
using System.Collections.Generic;
using UnityEngine;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      3/30/2018 1:56:17 PM
*  @Description:    
* ==============================================================================
*/

public class MoveComponent : MonoBehaviour
{
    public const string TAG = "MoveComponent";
    public float speed = 1;
    public Vector3 target;
    private Vector3 velocity;
    protected void Awake()
    {
        Loger.LogTag(TAG, "Awake");
    }

    protected void Start()
    {
        Loger.LogTag(TAG, "Start");
    }

    protected void Update()
    {
        Loger.LogTag(TAG, "Update " + transform.position);
        float distance = Vector3.Distance(transform.position, target);
        if(distance > 0.01f)
        {
            transform.position += velocity;
        }
    }

    public void MoveTo(Vector3 target)
    {
        Loger.LogTag(TAG, "MoveTo");
        this.target = target;
        velocity = (target - transform.position).normalized * speed;
    }
}