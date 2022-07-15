using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField ]private float scorePerUnit = 100;

    public static Score Instance;
    private float _score = 0;

    public float ScoreAmount => _score;

    public event UnityAction ScoreChange;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        TryUpdateScore();
    }

    private void TryUpdateScore()
    {
        if (_player.Height * scorePerUnit > _score)
        {
            _score = _player.Height * scorePerUnit;
            ScoreChange?.Invoke();
        }

    }

    public void ResetScore()
    {
        _score = 0;
        ScoreChange?.Invoke();
    }
}
