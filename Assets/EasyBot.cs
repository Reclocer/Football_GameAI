using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBot : BotControl
{
    [SerializeField] private float _maxRangeFromBall = 1f;
    [SerializeField] private bool _isBallNear;
    protected override void Update()
    {
        float distanceFromBall = Vector3.Distance(transform.position, _ball.transform.position);
        _isBallNear = distanceFromBall <= _maxRangeFromBall;

        if(_isBallNear)
        {
            Stop();
            return;
        }
        
        GoForBallLoop();
        
    }

    private void Stop()
    {
        X = 0;
        Y = 0;
    }
}
