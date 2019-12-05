using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUserControl : MonoBehaviour, IUserControl
{
    private float _x;
    public float X => _x;

    private float _y;
    public float Y => _y;

    public Object Object => this;
            
    void Update()
    {
        _x = Input.GetAxis("Mouse X");
        _y = Input.GetAxis("Mouse Y");
    }
}
