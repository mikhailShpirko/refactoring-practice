using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : BaseScoreMutator
{
    [SerializeField]
    private int _multiplier;

    public override int MutateScore(int currentScore)
    {
        return currentScore * _multiplier;
    }
}
