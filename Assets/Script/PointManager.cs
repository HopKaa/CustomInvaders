using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    private static PointManager _instance;

    private int _score;
    [SerializeField] private Text _scoreText;

    public static PointManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + _score;
    }
}
