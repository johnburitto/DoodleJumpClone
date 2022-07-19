using System;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField ]private float scorePerUnit = 100;

    public static Score Instance;
    private float _currentScore = 0;
    private float _hightScore = 0;

    public float CurrentScore => _currentScore;
    public float HightScore => _hightScore;

    public event UnityAction ScoreChange;

    private void Start()
    {
        Instance = this;
        LoadHightScore();
    }

    void Update()
    {
        TryUpdateScore();
    }

    private void TryUpdateScore()
    {
        if (_player.Height * scorePerUnit > _currentScore)
        {
            _currentScore = _player.Height * scorePerUnit;
            ScoreChange?.Invoke();
        }

    }

    public void ResetScore()
    {
        _currentScore = 0;
        ScoreChange?.Invoke();
    }

    public void SaveHightScore()
    {
        if (_currentScore > _hightScore)
        {
            PlayerPrefs.SetFloat("HightScore", _currentScore);
        }
    }

    public void LoadHightScore()
    {
        _hightScore = PlayerPrefs.GetFloat("HightScore");
        ScoreChange?.Invoke();
    }
}
