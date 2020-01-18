using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{    
    [SerializeField] private Color _teamColor;
    public Color TeamColor => _teamColor;    
}
