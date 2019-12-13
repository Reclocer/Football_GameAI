using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCounter : MonoBehaviour
{
    private Dictionary<int, int> _goalsDict = new Dictionary<int, int>();
    public Dictionary<int, int> GoalsDict => _goalsDict;

    [SerializeField] private Gate _gateTeam1;
    [SerializeField] private Gate _gateTeam2;
    public event Action<int, int> OnCounterChanged = (playerOjb, goalCount) => { };

    private void Awake()
    {
        _gateTeam1.OnGoal += IncrementGoal;
        _gateTeam2.OnGoal += IncrementGoal;
    }

    private void IncrementGoal(int teamNumber)
    {
        AddGoalToPlayer(teamNumber);     
        OnCounterChanged(teamNumber, _goalsDict[teamNumber]);
    }

    private void AddGoalToPlayer(int teamNumber)
    {
        if(_goalsDict.ContainsKey(teamNumber))
        {
            _goalsDict[teamNumber]++; 
        } else
        {
            _goalsDict.Add(teamNumber, 1);
        }
    }        
}
