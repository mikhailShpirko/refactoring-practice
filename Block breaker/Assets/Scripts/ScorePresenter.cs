using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    public void SetScore(int value)
    {
        _scoreText.text = $"Score: {value}";
    }
}
