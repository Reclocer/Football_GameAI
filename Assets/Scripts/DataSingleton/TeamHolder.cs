using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHolder : DoLSingleton<TeamHolder>
{
    [SerializeField] private SoccerTeam[] _soccerTeams;
    private Dictionary<TeamIndex, SoccerTeam> _teamsDict = 
        new Dictionary<TeamIndex, SoccerTeam>();

    protected override TeamHolder GetInstance()
    {
        return this;
    }

    protected override void Awake()
    {
        base.Awake();
        InitializeDict();
    }

    private void InitializeDict()
    {
        for(int i = 0; i < _soccerTeams.Length; i++)
        {
            var team = _soccerTeams[i];
            if(!_teamsDict.ContainsKey(team.TeamIndex))
            {
                _teamsDict.Add(team.TeamIndex, team);
            }
            else
            {
                Debug.LogError($"Team with index: {team.TeamIndex} already exists!");
            }
        }
    }

    public SoccerTeam GetTeamByIndex(TeamIndex index)
    {

        if (!_teamsDict.ContainsKey(index))
        {
            Debug.LogError($"Team with index: {index} not exists!");
            return null;
        }
            
        return _teamsDict[index];
    }
}
