using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Загружаем сцену под индексом 1 (твой коридор)
        SceneManager.LoadScene(1); 
    }

    public void ExitGame()
    {
        Debug.Log("Выход из игры...");
        Application.Quit();
    }
}