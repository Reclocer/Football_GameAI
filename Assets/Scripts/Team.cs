using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{    
    [SerializeField] private Color _teamColor;
    public Color TeamColor => _teamColor;    

    [SerializeField] private Player[] _teamPlayers;

    private void Awake()
    {
        //_teamPlayers = GetComponentInChildren<Player>().gameObject;
        //for (int i = 0; i < _teamPlayers.Length; i++)
        //{
        //    _teamPlayers[i].OnKick += OnPlayerKick;
        //    _teamPlayers[i].TeamNumber = 1;
        //}
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
   
}
