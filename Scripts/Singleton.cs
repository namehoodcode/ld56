using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// ����
/// </summary>
public class Singleton<T>
{
    private static readonly T instance = Activator.CreateInstance<T>();
    public static T Instance
    {
        get { return instance; }
    }
    public virtual void Init()
    {

    }

    public virtual void OnDestroy() 
    { 
    
    }

    public virtual void Update(float dt)
    {

    }
}
