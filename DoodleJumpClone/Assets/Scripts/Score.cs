using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;

    public static Score Instance;
    private float _score = 0;
    private const float SCORE_SCALER = 100;

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
        if (_player.Height * SCORE_SCALER > _score)
        {
            _score = _player.Height * SCORE_SCALER;
            ScoreChange?.Invoke();
        }

    }

    public void ResetScore()
    {
        _score = 0;
        ScoreChange?.Invoke();
    }
}
