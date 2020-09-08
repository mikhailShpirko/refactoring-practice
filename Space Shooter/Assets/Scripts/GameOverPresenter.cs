using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPresenter : MonoBehaviour
{
    [SerializeField]
    private GameObject _ui;

    [SerializeField]
    private Player _player;

    private void Awake()
    {
        _player.OnDestroyed += Show;
    }

    private void Start()
    {
        Hide();
    }
    private void OnDestroy()
    {
        _player.OnDestroyed -= Show;
    }

    private void Hide()
    {
        _ui.SetActive(false);
    }

    private void Show()
    {
        _ui.SetActive(true);
    }
}
