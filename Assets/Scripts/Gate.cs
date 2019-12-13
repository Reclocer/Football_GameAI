using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gate : MonoBehaviour
{
    public event Action<int> OnGoal = (teamNumber) => { };
  
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if(ball != null)
        {            
            OnGoal(ball.LastAffector.GetComponent<Player>().TeamNumber);
        }
    }   
}
