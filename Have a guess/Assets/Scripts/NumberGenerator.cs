using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour
{
    private const int _minNumberToGenerate = 1;
    private const int _maxNumberToGenerate = 1000;


    [SerializeField]
    public IntegerEvent OnNumberGenerated;

    private void Start()
    {
        var generatedNumber = Random.Range(_minNumberToGenerate, _maxNumberToGenerate);
        OnNumberGenerated?.Invoke(generatedNumber);
    }
}
