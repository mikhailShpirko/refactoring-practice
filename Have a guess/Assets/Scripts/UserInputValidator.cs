using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputValidator : MonoBehaviour
{
    [SerializeField]
    private InputField _inputField;

    [SerializeField]
    public IntegerEvent OnValid;

    [SerializeField]
    public VoidEvent OnInvalid;

    public void Validate()
    {
        if (int.TryParse(_inputField.text, out var inputNumber))
        {
            OnValid?.Invoke(inputNumber);
        }
        else
        {
            OnInvalid?.Invoke();
        }
    }
}
