using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField]
    private Score _score;

    private void Start()
    {
        _score.Value = 0;
    }

    public void UpdateScore(IScoreMutator mutator)
    {
        _score.Value = mutator.MutateScore(_score.Value);
    }

}
