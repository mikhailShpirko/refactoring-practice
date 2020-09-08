using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    private Text _uiText;
    
    [SerializeField]
    private PlaythroughScore _score;

    [SerializeField]
    private Player _player;

    private void Awake() 
    {
        _score.OnScoreChanged += UpdateScoreText;
        _player.OnDestroyed += Hide;
    }

    private void OnDestroy() 
    {
        _score.OnScoreChanged -= UpdateScoreText;
        _player.OnDestroyed -= Hide;
    }

    private void UpdateScoreText(int score)
    {
        _uiText.text = $"Score: {score}";
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
