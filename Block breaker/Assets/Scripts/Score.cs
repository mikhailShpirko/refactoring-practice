using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _value;

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            OnScoreChanged?.Invoke(_value);
        }
    }

    public IntEvent OnScoreChanged;
}
