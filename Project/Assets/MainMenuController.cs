using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Configuración de Escena")]
    [Tooltip("Nivel1")]
    [SerializeField] private string levelSceneName = "Nivel1";

    public void PlayGame()
    {
        if (!string.IsNullOrEmpty(levelSceneName))
        {
            SceneManager.LoadScene(levelSceneName);
        }
        else
        {
            Debug.LogError("Error: No has definido el nombre de la escena en el Inspector de Unity.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}