using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private UIGoalTextCounter _textCounterUIprefab;
    [SerializeField] private GoalCounter _goalCounter;
    private Vector2 _sizeForBlock = new Vector2(250f, 100f);    
    
    //Dictionary<TKey, TValue>
    private Dictionary<GameObject, UIGoalTextCounter> _teamViewsDict = new Dictionary<GameObject, UIGoalTextCounter>();

    private void Awake()
    {
        _goalCounter.OnCounterChanged += OnTeamGoal;
    }

    private void OnTeamGoal(GameObject team, int goalCount)
    {       
        if (_teamViewsDict.ContainsKey(team))
        {
            _teamViewsDict[team].SetText($"{team.name}: {goalCount}");
        }
        else
        {
            UIGoalTextCounter textCounter = Instantiate(_textCounterUIprefab, transform);
            _teamViewsDict.Add(team, textCounter);
            textCounter.SetText($"{team.name}: {goalCount}");

            //UIGoalTextCounter color
            Color uiGoalTextCounterColor = team.GetComponent<Team>().TeamColor;
            textCounter.GetComponent<Text>().color = uiGoalTextCounterColor; 

            //UIGoalTextCounter size
            RectTransform rect = textCounter.GetComponent<RectTransform>();

            if (rect != null)
                rect.sizeDelta = _sizeForBlock;
        }

        SortTeamsByGoals();        
    }

    private void SortTeamsByGoals()
    {
        var teamList = _goalCounter.GoalsDict.ToList();
        var sorted = teamList.OrderBy(pair => pair.Value).ToList();
        sorted.Reverse();
        int index = 1;
        int lastPoints = 0;

        foreach(var pair in sorted)
        {
            GameObject team = pair.Key;
            int teamPoints = pair.Value;
            UIGoalTextCounter textCounter = _teamViewsDict[team];
            textCounter.transform.SetSiblingIndex(index);

            if (teamPoints == lastPoints)
                textCounter.transform.SetSiblingIndex(index - 2);
            lastPoints = teamPoints;
            index++;
        }
       
    }
}
