using UnityEngine;
using System.Collections.Generic;

public class AnomalyController : MonoBehaviour
{
    public GameObject[] allAnomalies; 
    private List<int> remainingAnomalies = new List<int>();

    [Header("Настройки исчезновения")]
    public GameObject objectToHide; // Предмет, который изначально стоит в сцене
    public int indexOfHidingAnomaly; // ИНДЕКС аномалии из списка allAnomalies, которая его прячет

    public int currentScore = 0;
    public int currentAnomalyIndex = -1;

    void Awake()
    {
        for (int i = 0; i < allAnomalies.Length; i++)
        {
            remainingAnomalies.Add(i);
            allAnomalies[i].SetActive(false); 
        }
    }

    public void AddScore()
    {
        currentScore++;
        Debug.Log("Победная серия! Текущий счет: " + currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        Debug.Log("Счет сброшен! Начни сначала.");
    }

    public void GenerateNewLevel()
    {
        // 1. Возвращаем всё в нормальное состояние
        foreach (var a in allAnomalies) a.SetActive(false);
        if (objectToHide != null) objectToHide.SetActive(true); 
        currentAnomalyIndex = -1;

        int diceRoll = Random.Range(1, 15); 
        Debug.Log("Выпало число: " + diceRoll);

        if (diceRoll == 1 || diceRoll == 3 || diceRoll == 8 || diceRoll == 10)
        {
            Debug.Log("Число из списка 'пустых': Аномалий нет.");
        }
        else if (remainingAnomalies.Count > 0)
        {
            int randomIndex = Random.Range(0, remainingAnomalies.Count);
            int anomalyID = remainingAnomalies[randomIndex];
            currentAnomalyIndex = anomalyID;

            // 2. ПРОВЕРЯЕМ: выпала ли аномалия исчезновения?
            if (anomalyID == indexOfHidingAnomaly)
            {
                if (objectToHide != null) objectToHide.SetActive(false); // Скрываем объект
                Debug.Log("Активирована аномалия ИСЧЕЗНОВЕНИЯ: " + objectToHide.name);
            }
            else
            {
                // Если выпала любая другая аномалия — включаем её как обычно
                allAnomalies[anomalyID].SetActive(true);
                Debug.Log("Активирована обычная аномалия: " + allAnomalies[anomalyID].name);
            }

            remainingAnomalies.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("Список уникальных аномалий пуст, проход чистый.");
        }
    }
}