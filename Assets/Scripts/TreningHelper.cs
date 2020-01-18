using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreningHelper : MonoBehaviour
{
    //[SerializeField] private float _delayToReturn = 2;
    [SerializeField] private Ball _ball;
    [SerializeField] private PlayZone _playZone;

    private Vector3 _ballStartPosition;
    private Vector3 _ballPosition;
    private Coroutine _currentCoroutine;

    void Start()
    {        
        _ballStartPosition = _ball.transform.position;

        GoalCounter.Instance.OnCounterChanged += (obj, count) =>
        {
            ReturnBallToStartPosition();
        };
    }

    private void Update()
    {
        _ballPosition = _ball.transform.position;
        bool ballInZone = _playZone.IsOutOfBounds(_ballPosition);

        if (!ballInZone)
        {
            ReturnBallToStartPosition();
        }


    }

    //private void OnPlayerKick(IAffectableBody affectable)
    //{
    //    if (affectable == _ball as IAffectableBody)
    //    {
    //        if (_currentCoroutine == null)
    //            _currentCoroutine = StartCoroutine(ReturnBallCorutine());
    //    }
    //}

    private void ReturnBallToStartPosition()
    {
        _ball.transform.position = _ballStartPosition;
        _ball.Rigidbody.angularVelocity = Vector3.zero;
        _ball.Rigidbody.velocity = Vector3.zero;
    }

    //private IEnumerator ReturnBallCorutine()
    //{
    //    yield return new WaitForSeconds(_delayToReturn);
    //    ReturnBallToStartPosition();
    //    _currentCoroutine = null;
    //}
}
