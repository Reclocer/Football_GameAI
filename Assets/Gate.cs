using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gate : MonoBehaviour
{
    [SerializeField] private GoalCounter _goalCounter;    

    public event Action<GameObject> OnGoal = (goalPlayer) => { };

    private void Awake()
    {       
        _goalCounter.OnCounterChanged += ChangeColorOnLeaderColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if(ball != null)
        {
            
            OnGoal(ball.LastAffector);
        }
    }

    private void ChangeColorOnLeaderColor(GameObject empty, int empty1)
    {        
        Color gateColor = _goalCounter.Leader.GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshRenderer>().material.color = gateColor;
    }
}
