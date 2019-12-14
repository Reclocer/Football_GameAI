using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Team : MonoBehaviour
{    
    [SerializeField] protected Color _teamColor;
    public Color Team1Color => _teamColor;    

    [SerializeField] private Player[] _teamPlayers;

    protected virtual void Awake()
    {
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
