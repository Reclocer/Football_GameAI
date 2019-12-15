using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gate : MonoBehaviour
{
    public event Action<GameObject> OnGoal = (team) => { };
  
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if(ball != null)
        {
            GameObject team = ball.LastAffector.GetComponent<Player>().TeamObject;
            OnGoal(team);
        }
    }   
}
