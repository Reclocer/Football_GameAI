﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private UIGoalTextCounter _textCounterUIprefab;
    [SerializeField] private GoalCounter _goalCounter;
    private Vector2 _sizeForBlock = new Vector2(250f, 100f);
    private GameObject _lastLeader;// переменная для последнего лидера
    
    //Dictionary<TKey, TValue>
    private Dictionary<GameObject, UIGoalTextCounter> _playerViewsDict = new Dictionary<GameObject, UIGoalTextCounter>();


    private void Awake()
    {
        _goalCounter.OnCounterChanged += OnPlayerGoal;
    }

    private void OnPlayerGoal(GameObject playerObject, int goalCount)
    {       
        if (_playerViewsDict.ContainsKey(playerObject))
        {
            _playerViewsDict[playerObject].SetText($"{playerObject.name}:{goalCount}");
        }
        else
        {
            UIGoalTextCounter textCounter = Instantiate(_textCounterUIprefab, transform);
            _playerViewsDict.Add(playerObject, textCounter);
            textCounter.SetText($"{playerObject.name}:{goalCount}");

            //назначение цвета UI текста счетчика голов, в соответствии цвета игрока 
            Color textCounterColor = playerObject.GetComponent<MeshRenderer>().material.color;
            textCounter.GetComponent<Text>().color = textCounterColor;

            RectTransform rect = textCounter.GetComponent<RectTransform>();

            if (rect != null)
                rect.sizeDelta = _sizeForBlock;
        }

        SortPlayerByGoals();

        return;
        //вызов метода "назначение позиции в иерархии столбца чемпионов" 
        if (_goalCounter.Leader != null)
        {            
            AppointLeaderPlayer(_goalCounter.Leader);            
        }

    }

    // назначение позиции в иерархии столбца чемпионов 
    private void AppointLeaderPlayer(GameObject leader)
    {
        if (_lastLeader == null)
        {
            _playerViewsDict[leader].transform.SetSiblingIndex(0);
            _lastLeader = leader;
        }
        else if(leader != _lastLeader)
        {            
            _playerViewsDict[leader].transform.SetSiblingIndex(0);
            _playerViewsDict[_lastLeader].transform.SetSiblingIndex(1);
            _lastLeader = leader;
        }
    }

    private void SortPlayerByGoals()
    {
        var playerList = _goalCounter.GoalsDict.ToList();
        var sorted = playerList.OrderBy(pair => pair.Value).ToList();
        sorted.Reverse();
        int index = 1;
        int lastPoints = 0;

        foreach(var pair in sorted)
        {
            GameObject player = pair.Key;
            int playerPoints = pair.Value;
            UIGoalTextCounter textCounter = _playerViewsDict[player];
            textCounter.transform.SetSiblingIndex(index);

            if (playerPoints == lastPoints)
                textCounter.transform.SetSiblingIndex(index - 2);
            lastPoints = playerPoints;
            index++;
        }
       
    }
}