using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    private IUserControl _userControl;
    [SerializeField] private float _rotateSpeedHorizontal = 30;
    [SerializeField] private float _rotateSpeedVertical = 10;
    private Vector3 _rotateValue;
    
    void Start()
    {
        _userControl = GetComponent<IUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal rotate
        _rotateValue.x = _userControl.X * _rotateSpeedHorizontal * Time.deltaTime;        
        transform.Rotate(0, _rotateValue.x, 0);

        //vertical rotate
        //_rotateValue.y = _userControl.Y * _rotateSpeedVertical* Time.deltaTime;
        //transform.Rotate(_rotateValue.y, 0, 0);
    }

    public void SetControl(IUserControl userControl)
    {
        if (_userControl != null)
        {
            Destroy(_userControl.Object);
        }

        _userControl = userControl;
    }
}
