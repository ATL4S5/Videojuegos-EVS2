using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string nombreMenu = "MainMenu";

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(nombreMenu);
    }
}