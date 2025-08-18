using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Interactions;
public class GameManager : MonoBehaviour
{
    public GameObject gameOver;

    public TextMeshProUGUI bestRecordText;

    public TextMeshProUGUI timeText;
    private float coinScore;
    private bool isGameOver = false;

    private void Start()
    {
        gameOver.SetActive(false);
    }
    private void Update()
    {
        if (!isGameOver)
        {
            coinScore += Time.deltaTime;
            timeText.text = $"Score:{Mathf.FloorToInt(coinScore)}";
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
}
