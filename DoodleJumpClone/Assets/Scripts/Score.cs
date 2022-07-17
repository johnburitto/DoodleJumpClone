using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField ]private float scorePerUnit = 100;

    public static Score Instance;
    private float _currentScore = 0;
    private float _hightScore = 0;
    private string _filePath;

    public float CurrentScore => _currentScore;
    public float HightScore => _hightScore;

    public event UnityAction ScoreChange;

    private void Start()
    {
        Instance = this;
#if UNITY_ANDROID && !UNITY_EDITOR
        _filePath = Path.Combine(Application.persistentDataPath, "hightScore.txt");
#else
        _filePath = Path.Combine(Application.dataPath, "hightScore.txt");
#endif
        LoadScore();
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

    public void SaveScore()
    {
        StreamWriter sw = new StreamWriter(_filePath);

        if (_currentScore > _hightScore)
        {
            sw.WriteLine(_currentScore);
        }
        else
        {
            sw.WriteLine(_hightScore);
        }

        sw.Close();
    }

    public void LoadScore()
    {
        StreamReader sr = new StreamReader(_filePath);

        try
        {
            _hightScore = float.Parse(sr.ReadLine());
        }
        catch (Exception e)
        {
#if UNITY_EDITOR
            Debug.Log(e);
#endif
            _hightScore = 0;
        }

        ScoreChange?.Invoke();
        sr.Close();
    }
}
