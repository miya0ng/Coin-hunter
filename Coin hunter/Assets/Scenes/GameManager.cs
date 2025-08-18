using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Interactions;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOver;

    public TextMeshProUGUI bestRecordText;
    public TextMeshProUGUI scoreText;

    private float coinScore;
    private bool isGameOver = false;
  
    private void Start()
    {
        Instance = this;
        gameOver.SetActive(false);
    }
    private void Update()
    {
        if (!isGameOver)
        {
            scoreText.text = $"Score:{Mathf.FloorToInt(coinScore)}";
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOver.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestTime", 0f);
        if (bestScore < coinScore)
        {
            bestScore = coinScore;
            PlayerPrefs.SetFloat("BestTime", bestScore);
        }
        bestRecordText.text = $"Best Record:{Mathf.FloorToInt(bestScore)}";
    }

    public void AddScore(int amount)
    {
        coinScore += amount;
    }
}
