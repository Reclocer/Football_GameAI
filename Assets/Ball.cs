using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IAffectableBody
{
    private Rigidbody _rigidBody;
    public Rigidbody Rigidbody => _rigidBody;

    private GameObject _lastAffector;
    public GameObject LastAffector => _lastAffector;

    public void Collide(Vector3 direction, float power, GameObject sender)
    {
        _lastAffector = sender;
        _rigidBody.AddForce(direction * power);
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
}
