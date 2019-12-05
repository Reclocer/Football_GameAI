using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardUserControll : MonoBehaviour, IUserControl
{
    private float _x;
    public float X { get { return _x; } } //traditional
    public float Y { get; private set; } //auto-property

    public Object Object => this;
        
    void Update()
    {
        _x = Input.GetAxis("Horizontal");        
        Y = Input.GetAxis("Vertical");
    }

    public Object GetObject()
    {
        return this;
    }
}
