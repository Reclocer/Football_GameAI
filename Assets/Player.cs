using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IUserControl _userControl;//2.Создание переменной interface типа
    [SerializeField] private float _speed = 5;
    [SerializeField] private Vector3 _currentVelocity;
    private Rigidbody _rigidbody;
    [SerializeField] private float _kickPower = 200;
    public event Action<IAffectableBody> OnKick = (body) => { }; 

    void Awake()
    {
        InitializeLinks(); //3
    }
    
    private void InitializeLinks()
    {
        _userControl = GetComponent<IUserControl>();
        _rigidbody = GetComponent<Rigidbody>();
    }
        
    void FixedUpdate()
    {
        UpdateVelosityView();
        
        if (_userControl == null)
            return;
        Vector3 movePosition = new Vector3(_userControl.X, 0f, _userControl.Y);

        _rigidbody.velocity = movePosition * _speed * Time.fixedDeltaTime;

        ////4.Перемещение объекта в координаты, которые сообщает нам IUserControl
        //transform.Translate(movePosition * _speed * Time.deltaTime); 

    }

    //5.Исполнение Singleton контроллера
    public void SetControl(IUserControl userControl)
    {
        if(_userControl != null)
        {
            Destroy(_userControl.Object);
        }

        _userControl = userControl;
    }

    private void UpdateVelosityView()
    {
        _currentVelocity = _rigidbody.velocity;
    }

    private void Kick(IAffectableBody affect)
    {
        Vector3 kickVector = new Vector3(_rigidbody.velocity.x,
            _rigidbody.velocity.magnitude,
            _rigidbody.velocity.z);
        affect.Collide(kickVector, _kickPower, this.gameObject);
        OnKick(affect);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IAffectableBody affectableBody = collision.gameObject.GetComponent<IAffectableBody>();
        if(affectableBody != null)
        {
            Kick(affectableBody);
            //Debug.Log($"Kick to {collision.gameObject.name} !");
        }
    }

}
