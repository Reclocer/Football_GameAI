using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gate : MonoBehaviour
{
    public event Action<GameObject> OnGoal = (team) => { };
    [SerializeField] private GameObject _team;
    [SerializeField] private GameObject _enemyTeam;

    private void Awake()
    {
        Color teamColor = _team.GetComponent<Team>().TeamColor;
        GetComponent<MeshRenderer>().material.color = teamColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if(ball != null)
        {
            //GameObject team = ball.LastAffector.GetComponent<Player>().TeamObject;            
            OnGoal(_enemyTeam);
        }
    }   
}
