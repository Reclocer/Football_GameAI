using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public event Action<SoccerTeam> OnGoal = (team) => { };
    private SoccerTeam _enemyTeam;
    [SerializeField] private TeamIndex _teamIndex;    

    private void Start()
    {
        EnemyTeamAppointment(_teamIndex);
        Color teamColor = TeamHolder.Instance.GetTeamByIndex(_teamIndex).TeamColor;
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
    
    private void EnemyTeamAppointment(TeamIndex teamIndex)
    {
        if(teamIndex == TeamIndex.Team1)
        {
            _enemyTeam = TeamHolder.Instance.GetTeamByIndex(TeamIndex.Team2);
        }
        else
        {
            _enemyTeam = TeamHolder.Instance.GetTeamByIndex(TeamIndex.Team1);
        }
    }
}
