using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreningHelper : MonoBehaviour
{
    [SerializeField] private float _delayToReturn = 2;
    [SerializeField] private Ball _ball;
    [SerializeField] private Player[] _player;
    private Vector3 _ballStartPosition;
    private Coroutine _currentCoroutine;
        
    void Start()
    {
        for(int i = 0; i < _player.Length; i++)
        {
            _player[i].OnKick += OnPlayerKick;
        }

        _ballStartPosition = _ball.transform.position;
    }
        
    private void OnPlayerKick(IAffectableBody affectable)
    {
        if (affectable == _ball)
        {
            if(_currentCoroutine == null)
                _currentCoroutine = StartCoroutine(ReturnBallCorutine());
        }
    }

    private void ReturnBallToStartPosition()
    {
        _ball.transform.position = _ballStartPosition;
        _ball.Rigidbody.angularVelocity = Vector3.zero;
        _ball.Rigidbody.velocity = Vector3.zero;
    }

    private IEnumerator ReturnBallCorutine()
    {
        yield return new WaitForSeconds(_delayToReturn);
        ReturnBallToStartPosition();
        _currentCoroutine = null;
    }
}
