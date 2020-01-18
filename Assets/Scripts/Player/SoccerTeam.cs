using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoccerTeam
{
    [SerializeField] private TeamIndex _teamIndex;
    public TeamIndex TeamIndex => _teamIndex;

    [SerializeField] private Color _teamColor;
    public Color TeamColor => _teamColor;
}
