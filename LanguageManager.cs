using UnityEngine;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    [Header("Кнопки текста")]
    public TextMeshProUGUI playText;
    public TextMeshProUGUI aboutText;
    public TextMeshProUGUI exitText;

    void Start()
    {
        // Проверяем язык через строку, так надежнее
        string systemLang = Application.systemLanguage.ToString();
        
        if (systemLang == "Russian")
        {
            SetText("ИГРАТЬ", "ОБ АВТОРЕ", "ВЫХОД");
        }
        else if (systemLang == "Uzbek")
        {
            SetText("O'YNASH", "MUALLIF HAQIDA", "CHIQISH");
        }
        else
        {
            SetText("PLAY", "ABOUT", "EXIT");
        }
    }

    void SetText(string p, string a, string e)
    {
        playText.text = p;
        aboutText.text = a;
        exitText.text = e;
    }

    public void PlayGame()
    {
    // Эта команда загружает следующую сцену в списке сборки
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); 
    }
    public void ExitGame() { Application.Quit(); Debug.Log("Exit"); }
    
    public void OpenAbout() 
    { 
        Debug.Log("Автор: Ойбек");
        Application.OpenURL("https://t.me/myprogramming_life"); 
    }
}