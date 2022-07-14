using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _text;

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
        _text.text = Mathf.Round(_score.ScoreAmount).ToString();
    }
}
