using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCounter : MonoBehaviour
{
    private Dictionary<GameObject, int> _goalsDict = new Dictionary<GameObject, int>();
    [SerializeField] private Gate _gate;
    public event Action<GameObject, int> OnCounterChanged = (playerOjb, goalCount) => { };

    //переменные для выбора лидера
    private GameObject _leader;
    public GameObject Leader => _leader;
    private int _maxGoal = 0;

    private void Awake()
    {
        _gate.OnGoal += IncrementGoal;        
    }

    private void IncrementGoal(GameObject lastAffector)
    {
        AddGoalToPlayer(lastAffector);
        ChoiceLeaderPlayer(lastAffector);//выбор лидера среди игроков
        OnCounterChanged(lastAffector, _goalsDict[lastAffector]);
    }

    private void AddGoalToPlayer(GameObject playerGameObject)
    {
        if(_goalsDict.ContainsKey(playerGameObject))
        {
            _goalsDict[playerGameObject]++; 
        } else
        {
            _goalsDict.Add(playerGameObject, 1);
        }
    }

    //выбор лидера среди игроков
    // параметр метода не используется в методе, и нужен только для соответствия сигнатуре события OnGoal
    private void ChoiceLeaderPlayer(GameObject empty)
    {          
        foreach (GameObject player in _goalsDict.Keys)
        {            
            if (_goalsDict[player] > _maxGoal)
            {
                _maxGoal = _goalsDict[player];
                _leader = player;                           
            }
        }        
    }
}
