using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class PersistentData : MonoBehaviour
{

    public static PersistentData Instance;
    [SerializeField] private int playerScore;
    [SerializeField] private string playerName;
    private List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    public int maxHighScores = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddHighScore(string name, int score)
    {
        highScores.Add(new HighScoreEntry { playerName = name, score = score });
        highScores = highScores.OrderByDescending(s => s.score).ToList();
        // Optionally limit the number of high scores here
    }

    public List<HighScoreEntry> GetHighScores()
    {
        return highScores;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerName = "";

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

}
