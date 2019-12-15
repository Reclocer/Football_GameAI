using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCounter : MonoBehaviour
{
    private Dictionary<GameObject, int> _goalsDict = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, int> GoalsDict => _goalsDict;

    [SerializeField] private Gate _gateTeam1;
    [SerializeField] private Gate _gateTeam2;
    public event Action<GameObject, int> OnCounterChanged = (team, goalCount) => { };

    private void Awake()
    {
        _gateTeam1.OnGoal += IncrementGoal;
        _gateTeam2.OnGoal += IncrementGoal;
    }

    private void IncrementGoal(GameObject team)
    {
        AddGoalToTeam(team);     
        OnCounterChanged(team, _goalsDict[team]);
    }

    private void AddGoalToTeam(GameObject team)
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
