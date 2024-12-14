using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI titleText;                // Texto del t�tulo
    public TextMeshProUGUI playTask1ButtonText;      // Texto del bot�n para Task1
    public TextMeshProUGUI playTask2ButtonText;      // Texto del bot�n para Task2
    public TextMeshProUGUI exitButtonText;           // Texto del bot�n para salir
    public TMP_Dropdown languageDropdown;     // Dropdown para seleccionar idioma

    [Header("Localization")]
    private string currentLanguage = "en"; // Idioma actual ("en" para ingl�s, "es" para espa�ol)

    private void Start()
    {
        // Configurar el Dropdown de idiomas
        languageDropdown.onValueChanged.AddListener(ChangeLanguage);
        UpdateTexts();
    }

    // Cambiar de idioma
    public void ChangeLanguage(int index)
    {
        currentLanguage = index == 0 ? "en" : "es";
        UpdateTexts();
    }

    // Actualizar los textos seg�n el idioma actual
    private void UpdateTexts()
    {
        if (currentLanguage == "en")
        {
            titleText.text = "Main Menu";
            playTask1ButtonText.text = "Play Task 1";
            playTask2ButtonText.text = "Play Task 2";
            exitButtonText.text = "Exit";
        }
        else if (currentLanguage == "es")
        {
            titleText.text = "Men� Principal";
            playTask1ButtonText.text = "Jugar Tarea 1";
            playTask2ButtonText.text = "Jugar Tarea 2";
            exitButtonText.text = "Salir";
        }
    }

    // Cargar la escena de Task1
    public void PlayTask1()
    {
        SceneManager.LoadScene("Task 1");
    }

    // Cargar la escena de Task2
    public void PlayTask2()
    {
        SceneManager.LoadScene("Task 2");
    }

    // Salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
