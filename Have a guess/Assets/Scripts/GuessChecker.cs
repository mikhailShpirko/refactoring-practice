using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessChecker : MonoBehaviour
{
    private int _correctNumber;

    public CheckResultEvent OnChecked;

    public void SetCorrectNumber(int correctNumber)
    {
        _correctNumber = correctNumber;
    }

    public void Check(int userInputNumber)
    {
        CheckResult result;

        if (userInputNumber > _correctNumber)
        {
            result = CheckResult.Higher;
        }
        else if (userInputNumber < _correctNumber)
        {
            result = CheckResult.Lower;
        }
        else
        {
            result = CheckResult.Equal;
        }

        OnChecked?.Invoke(result);
    }
}
