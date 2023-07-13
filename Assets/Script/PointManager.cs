using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    private int _score;
    [SerializeField] private Text _scoreText;

    void Start()
    {
        
    }

    public void UpdateScore(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + _score;
    }
}
