using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControl : MonoBehaviour, IUserControl
{
    protected Ball _ball;

    public float X { get; protected set;}

    public float Y { get; protected set; }

    public Object Object => this;

    protected virtual void Awake()
    {
        _ball = FindObjectOfType<Ball>();
    }

    protected virtual void Update()
    {
        GoForBallLoop();
    }

    protected virtual void GoForBallLoop()
    {
        Vector3 relativePos = _ball.transform.position - transform.position;

        X = relativePos.normalized.x;
        Y = relativePos.normalized.z;
    }
}
