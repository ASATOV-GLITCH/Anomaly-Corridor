using UnityEngine;

public class PathChoice : MonoBehaviour
{
    public AnomalyController manager;
    public Transform startPoint;
    public bool isRightDoor; // На правом триггере поставь галочку, на левом — нет

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ПРОВЕРЯЕМ: есть ли сейчас аномалия в менеджере?
            bool anomalyActive = manager.currentAnomalyIndex != -1;

            if (anomalyActive && isRightDoor)
            {
                // Правильно: была аномалия и ты пошел в ПРАВУЮ дверь
                Debug.Log("Верно! Аномалия замечена.");
                ProcessResult(other.gameObject, true);
            }
            else if (!anomalyActive && !isRightDoor)
            {
                // Правильно: аномалии НЕ БЫЛО и ты пошел в ЛЕВУЮ дверь
                Debug.Log("Верно! Аномалий нет.");
                ProcessResult(other.gameObject, true);
            }
            else
            {
                // Ошибка в любом другом случае
                Debug.Log("ОШИБКА! Ты выбрал неверный путь.");
                ProcessResult(other.gameObject, false);
            }
        }
    }

    void ProcessResult(GameObject player, bool success)
    {
        // 1. Телепорт (твой старый код)
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        player.transform.position = startPoint.position;
        if (cc != null) cc.enabled = true;

    // 2. СВЯЗЬ СО СЧЕТЧИКОМ (Исправляем здесь)
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); 
    
        if (scoreManager != null) {
            if (success) {
                scoreManager.AddPoint(); // Прибавит только если успех
                Debug.Log("Счет увеличен!");
            } else {
                scoreManager.ResetScore(); // Обнулит если ошибка
                Debug.Log("Счет обнулен!");
            }
        }

    // 3. Создаем новую аномалию
        if (manager != null) manager.GenerateNewLevel();
        }
    }
