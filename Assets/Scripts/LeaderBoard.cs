using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private UIGoalTextCounter _textCounterUIprefab;
    [SerializeField] private GoalCounter _goalCounter;
    private Vector2 _sizeForBlock = new Vector2(250f, 100f);    
    
    //Dictionary<TKey, TValue>
    private Dictionary<int, UIGoalTextCounter> _teamViewsDict = new Dictionary<int, UIGoalTextCounter>();

    private void Awake()
    {
        _goalCounter.OnCounterChanged += OnTeamGoal;
    }

    private void OnTeamGoal(int teamNumber, int goalCount)
    {       
        if (_teamViewsDict.ContainsKey(teamNumber))
        {
            _teamViewsDict[teamNumber].SetText($"Team{teamNumber}: {goalCount}");
        }
        else
        {
            UIGoalTextCounter textCounter = Instantiate(_textCounterUIprefab, transform);
            _teamViewsDict.Add(teamNumber, textCounter);
            textCounter.SetText($"Team{teamNumber}: {goalCount}");            

            RectTransform rect = textCounter.GetComponent<RectTransform>();

            if (rect != null)
                rect.sizeDelta = _sizeForBlock;
        }

        SortTeamsByGoals();        
    }

    private void SortTeamsByGoals()
    {
        var playerList = _goalCounter.GoalsDict.ToList();
        var sorted = playerList.OrderBy(pair => pair.Value).ToList();
        sorted.Reverse();
        int index = 1;
        int lastPoints = 0;

        foreach(var pair in sorted)
        {
            int teamNumber = pair.Key;
            int teamPoints = pair.Value;
            UIGoalTextCounter textCounter = _teamViewsDict[teamNumber];
            textCounter.transform.SetSiblingIndex(index);

            if (teamPoints == lastPoints)
                textCounter.transform.SetSiblingIndex(index - 2);
            lastPoints = teamPoints;
            index++;
        }
       
    }
}
