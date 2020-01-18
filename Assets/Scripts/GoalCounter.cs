using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCounter : MonoBehaviour
{
    public static GoalCounter Instance { get; private set; }

    private Dictionary<SoccerTeam, int> _goalsDict = new Dictionary<SoccerTeam, int>();
    public Dictionary<SoccerTeam, int> GoalsDict => _goalsDict;

    [SerializeField] private Gate _gateTeam1;
    [SerializeField] private Gate _gateTeam2;
    public event Action<SoccerTeam, int> OnCounterChanged = (team, goalCount) => { };

    private void Awake()
    { 
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this.gameObject);
        }
        _gateTeam1.OnGoal += IncrementGoal;
        _gateTeam2.OnGoal += IncrementGoal;
    }

    private void IncrementGoal(SoccerTeam team)
    {
        AddGoalToTeam(team);     
        OnCounterChanged(team, _goalsDict[team]);
        //_gateTeam1.OnGoal -= IncrementGoal;
        //_gateTeam2.OnGoal -= IncrementGoal;
    }

    private void AddGoalToTeam(SoccerTeam team)
    {
        if(_goalsDict.ContainsKey(team))
        {
            _goalsDict[team]++; 
        }
        else
        {
            _goalsDict.Add(team, 1);
        }
    }        
}
