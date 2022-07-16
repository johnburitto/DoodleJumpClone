using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _hightScore;

    private void OnEnable()
    {
        _score.ScoreChange += OnScoreChange;
    }

    private void OnDisable()
    {
        _score.ScoreChange -= OnScoreChange;
    }

    private void OnScoreChange()
    {
        _currentScore.text = Mathf.Round(_score.CurrentScore).ToString();
        _hightScore.text = Mathf.Round(_score.HightScore).ToString();
    }
}
