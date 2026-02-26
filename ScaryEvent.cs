using UnityEngine;
using System.Collections;

public class ScaryEvent : MonoBehaviour
{
    public DoorController theDoor; // Перетащи сюда свою дверь
    private bool playerLooked = false;

    private void OnTriggerEnter(Collider other)
    {
        // Если игрок вошел в зону перед глазами и это аномалия
        if (other.CompareTag("Player") && !playerLooked)
        {
            playerLooked = true;
            StartCoroutine(CloseDoorAfterDelay(5f));
        }
    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (theDoor != null)
        {
            theDoor.isOpen = false; // Дверь захлопывается
            // Можно добавить звук хлопка здесь
            Debug.Log("Дверь захлопнулась!");
        }
    }
}