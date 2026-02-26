using UnityEngine;

public class AnomalyTrigger : MonoBehaviour
{
    // Сюда мы перетащим наш AnomalyManager в инспекторе
    public AnomalyController manager; 

    // Эта функция встроена в Unity, она сама "поймет", когда игрок вошел
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что вошел именно игрок (у твоего игрока должен быть тег "Player")
        if (other.CompareTag("Player"))
        {
            // Даем команду менеджеру выбрать новую аномалию
            manager.GenerateNewLevel();
            
            Debug.Log("Игрок прошел через триггер! Генерируем аномалию...");
        }
    }
}