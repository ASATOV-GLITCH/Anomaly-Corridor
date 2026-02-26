using UnityEngine;
using UnityEngine.SceneManagement; // Для смены сцен

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Загрузит следующую сцену (твою игру)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenAbout()
    {
        // Пока просто выведем в консоль, позже сделаем окно
        Debug.Log("Автор: Ойбек. Проект: Aether Trials");
        Application.OpenURL("https://твоё-портфолио.com"); // Можно открыть твой сайт
    }

    public void ExitGame()
    {
        Debug.Log("Выход из игры...");
        Application.Quit(); // Закроет игру (работает только в собранной версии)
    }
}