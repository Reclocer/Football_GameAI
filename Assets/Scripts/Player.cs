using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected IUserControl _userControl;//2.Создание переменной interface типа
    [SerializeField] protected float _speed = 5;
    [SerializeField] protected Vector3 _currentVelocity;
    protected Rigidbody _rigidbody;
    [SerializeField] protected float _kickPower = 200;
    public event Action<IAffectableBody> OnKick = (body) => { };
    
    //team marker
    protected int _teamNumber = 1;
    public int TeamNumber
    {
        get
        {
            return _teamNumber;
        }
        set
        {
            _teamNumber = value;
        }
    }
    [SerializeField] protected MeshRenderer _teamMarker;
    

    protected void Start()
    {
        InitializeLinks(); //3
        ChangeTeamColor();

    }

    protected void InitializeLinks()
    {
        _userControl = GetComponent<IUserControl>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        UpdateVelosityView();
        
        if (_userControl == null)
            return;
        Vector3 movePosition = new Vector3(_userControl.X, 0f, _userControl.Y);
        
        _rigidbody.velocity = movePosition * _speed * Time.fixedDeltaTime;

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

    protected void UpdateVelosityView()
    {
        _currentVelocity = _rigidbody.velocity;
    }

    protected void Kick(IAffectableBody affect)
    {
        Vector3 kickVector = new Vector3(_rigidbody.velocity.x,
            _rigidbody.velocity.magnitude,
            _rigidbody.velocity.z);
        affect.Collide(kickVector, _kickPower, this.gameObject);
        OnKick(affect);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        IAffectableBody affectableBody = collision.gameObject.GetComponent<IAffectableBody>();
        if(affectableBody != null)
        {
            Kick(affectableBody);
            //Debug.Log($"Kick to {collision.gameObject.name} !");            
        }
    }

    protected void ChangeTeamColor()
    {
        if(_teamNumber <= 1)
        {
            _teamMarker.material.color = Color.blue;
        }
        else
        {
            _teamMarker.material.color = Color.red;
        }
    }

}
