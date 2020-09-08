using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaythroughScore : MonoBehaviour, IScore
{
    private int _value;

    private void Start() 
    {
        ChageScore(0);
    }
    private void ChageScore(int newScore)
    {
        _value = newScore;
        OnScoreChanged?.Invoke(_value);
    }

    public void AddScore(int score)
    {
        ChageScore(_value += score);
    }

    public event Action<int> OnScoreChanged;
}
