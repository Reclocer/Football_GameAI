using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] private TeamIndex _teamIndex;
    protected IUserControl _userControl;
    [SerializeField] protected float _speed = 5;
    [SerializeField] protected Vector3 _currentVelocity;
    protected Rigidbody _rigidbody;
    [SerializeField] protected float _kickPower = 200;
    //public event Action<IAffectableBody> OnKick = (body) => { };    
    
    //team 
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
    protected Color _teamColor;
    public Color TeamColor => _teamColor;
    

    protected virtual void Start()
    {        
        InitializeLinks();              
    }

    protected void InitializeLinks()
    {        
        _userControl = GetComponent<IUserControl>();
        _rigidbody = GetComponent<Rigidbody>();

        //set team color               
        _teamColor = TeamHolder.Instance.GetTeamByIndex(_teamIndex).TeamColor;
        _teamMarker.material.color = _teamColor;
    }

    protected virtual void FixedUpdate()
    {
        UpdateVelosityView();
        
        if (_userControl == null)
            return;

        Vector3 movePosition = new Vector3(_userControl.X, 0f, _userControl.Y);
        
        _rigidbody.velocity = movePosition * _speed * Time.fixedDeltaTime;
    }
        
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
        //OnKick(affect);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        IAffectableBody affectableBody = collision.gameObject.GetComponent<IAffectableBody>();
        if(affectableBody != null)
        {
            Kick(affectableBody);           
        }
    }
}
