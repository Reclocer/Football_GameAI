using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{    
    [SerializeField] private UIGoalTextCounter _textCounterUIprefab;
    private Vector2 _sizeForBlock = new Vector2(250f, 100f); // UI block    
    
    private Dictionary<SoccerTeam, UIGoalTextCounter> _teamViewsDict = 
        new Dictionary<SoccerTeam, UIGoalTextCounter>();

    private void Start()
    {        
        GoalCounter.Instance.OnCounterChanged += OnTeamGoal;
    }

    private void OnTeamGoal(SoccerTeam team, int goalCount)
    {       
        if (_teamViewsDict.ContainsKey(team))
        {
            _teamViewsDict[team].SetText($"{team.TeamIndex}: {goalCount}");
        }
        else
        {
            UIGoalTextCounter textCounter = Instantiate(_textCounterUIprefab, transform);
            _teamViewsDict.Add(team, textCounter);            
            textCounter.SetText($"{team.TeamIndex}: {goalCount}");

            //UIGoalTextCounter color            
            Color uiGoalTextCounterColor = team.TeamColor;
            textCounter.GetComponent<Text>().color = uiGoalTextCounterColor;            

            //UIGoalTextCounter size
            RectTransform rect = textCounter.GetComponent<RectTransform>();

            if (rect != null)
                rect.sizeDelta = _sizeForBlock;
        }

        SortTeamsByGoals();
        //GoalCounter.Instance.OnCounterChanged -= OnTeamGoal;
    }

    private void SortTeamsByGoals()
    {
        var teamList = GoalCounter.Instance.GoalsDict.ToList();
        var sorted = teamList.OrderBy(pair => pair.Value).ToList();
        sorted.Reverse();
        int index = 1;
        int lastPoints = 0;

        foreach(var pair in sorted)
        {
            SoccerTeam team = pair.Key;
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
