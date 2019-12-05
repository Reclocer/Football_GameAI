using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControl : MonoBehaviour, IUserControl
{
    [SerializeField] private Ball _ball;

    public float X { get; private set;}

    public float Y { get; private set; }

    public Object Object => this;

    private void Update()
    {
        GoForBallLoop();
    }

    private void GoForBallLoop()
    {
        Vector3 relativePos = _ball.transform.position - transform.position;

        X = relativePos.normalized.x;
        Y = relativePos.normalized.z;
    }
}
