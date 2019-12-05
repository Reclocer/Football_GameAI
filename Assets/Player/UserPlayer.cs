using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : Player
{
    [SerializeField] private float _rotSpeed = 80f;
    protected override void FixedUpdate()
    {
        float mouseAxis = Input.GetAxis("Mouse X");
        UpdateVelosityView();

        if (_userControl == null)
            return;
        //Rotation Logic
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * _rotSpeed * mouseAxis * Time.deltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);

        Vector3 movementControl = new Vector3(_userControl.X, 0f, _userControl.Y);
        Vector3 forward = transform.forward * movementControl.z;
        Vector3 right = transform.right * movementControl.x;

        _rigidbody.velocity = forward + right * _speed * Time.deltaTime;
       
    }
}
