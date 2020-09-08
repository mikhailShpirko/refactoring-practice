using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField]
    private int _scoreWeight;
    private IScore _score;

    private void Awake()
    {
        _score = FindObjectOfType<PlaythroughScore>();
    }

    private void OnDisable()
    {
        _score.AddScore(_scoreWeight);
    }
    
}
