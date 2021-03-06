﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IAffectableBody
{
    private Rigidbody _rigidBody;
    public Rigidbody Rigidbody => _rigidBody;

    private GameObject _lastAffector;
    public GameObject LastAffector => _lastAffector;    

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Collide(Vector3 direction, float power, GameObject sender)
    {
        //On collide !
        _lastAffector = sender;
        _rigidBody.AddForce(direction * power);
    }
}
