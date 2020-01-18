using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoLSingleton<T> : MonoBehaviour
{
    public static T Instance { get; protected set; }
    protected abstract T GetInstance();

    protected virtual void Awake()
    {
        if (Instance == null)
            Instance = GetInstance();

        DontDestroyOnLoad(this.gameObject);
    }
}
