using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // ОБЯЗАТЕЛЬНО добавь эту строку в самый верх!

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void AddPoint()
    {
        score++;
        UpdateUI();
        
        // Проверка условия победы
        if (score >= 10)
        {
            WinGame();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void WinGame()
    {
        Debug.Log("Победа! Возвращаемся в меню.");
        // Замени "MainMenu" на точное название своей сцены с меню
        SceneManager.LoadScene("MainMenu"); 
    }
}