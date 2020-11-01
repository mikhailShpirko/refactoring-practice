using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrementor : BaseScoreMutator
{
    [SerializeField]
    private int _scorePoints;
    
    public override int MutateScore(int currentScore)
    {
        return currentScore + _scorePoints;
    }
}
