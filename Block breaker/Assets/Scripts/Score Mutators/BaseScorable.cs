using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScoreMutator : MonoBehaviour, IScoreMutator
{
    public IScoreMutatorEvent OnDestroyed;

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    public abstract int MutateScore(int currentScore);
}
