using UnityEngine;
using UnityEngine.SceneManagement; // Нужно для перезагрузки уровня

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Синглтон, чтобы к менеджеру можно было обратиться из любого скрипта

    public int itemsCollected = 0;
    public int itemsToWin = 5; // Сколько предметов нужно собрать для победы

    private void Awake()
    {
        // Создаем инстанс, чтобы другие скрипты могли легко найти GameManager
        if (instance == null) instance = this;
    }

    public void AddItem()
    {
        itemsCollected++;
        Debug.Log("Предметов собрано: " + itemsCollected);

        if (itemsCollected >= itemsToWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("Ты собрал всё и выжил в этой школе!");
        // Здесь можно добавить переход на экран победы или в главное меню
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}