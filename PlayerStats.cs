using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;      // Здоровье (от 0 до 100)
    public int medKits = 1;       // Сколько аптечек с собой на старте
    public bool isAlive = true;   // Жив ли игрок

    // Функция вызова лечения (например, на кнопку 'H')
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && medKits > 0 && health < 100)
        {
            health = 100; // Полное исцеление
            medKits--;    // Тратим одну аптечку
            Debug.Log("Вы подлечились! Осталось аптечек: " + medKits);
        }

        if (health <= 0)
        {
            isAlive = false;
            Debug.Log("Игра окончена. Вас поймали.");
        }
    }
}