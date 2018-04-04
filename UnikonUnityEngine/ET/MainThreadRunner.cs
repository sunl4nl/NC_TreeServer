using System;
using System.Collections.Generic;
using System.Threading;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      3/30/2018 3:47:56 PM
*  @Description:    
* ==============================================================================
*/

public class MainThreadRunner
{
    public static OneThreadSynchronizationContext context { get; private set; }
    public static void Install()
    {
        context = new OneThreadSynchronizationContext();
        //SynchronizationContext.SetSynchronizationContext(context);
    }

    public static void Update()
    {
        context.Update();
    }

    public static void Post(SendOrPostCallback callback, object state)
    {
        context.Post(callback, state);
    }

    public static void Run(Action callback)
    {
        context.Run(callback);
    }


}