using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Score")]
    [SerializeField] private float scoreGainSpeed = 10f;

    private float score;
    private bool isGameOver;

    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        score += scoreGainSpeed * Time.deltaTime;
        UpdateScoreUI();
    }

    public void StartGame()
    {
        score = 0f;
        isGameOver = false;

        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        UpdateScoreUI();
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateScoreUI()
    {
        if (scoreText == null)
        {
            return;
        }

        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }
}
