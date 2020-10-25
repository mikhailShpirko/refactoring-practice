using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPresenter : MonoBehaviour
{
    [SerializeField]
    private Text _resultText;

    private readonly Dictionary<CheckResult, string> _checkResultMessages = new Dictionary<CheckResult, string>
    {
        {CheckResult.Higher, "My number is lower" },
        {CheckResult.Lower, "My number is higher" },
        {CheckResult.Equal, "Yes! Correct! You did it!" }
    };

    private void Start()
    {
        SetResultText(string.Empty);
    }

    private void SetResultText(string text)
    {
        _resultText.text = text;
    }

    public void SetInvalidText()
    {
        SetResultText("Please enter a number");
    }

    public void SetCheckResultText(CheckResult result)
    {
        if (_checkResultMessages.ContainsKey(result))
        {
            SetResultText(_checkResultMessages[result]);
        }
    }
}
