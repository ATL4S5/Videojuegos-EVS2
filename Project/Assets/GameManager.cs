using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Referencias")]
    [SerializeField] private TextMeshProUGUI monedaText;
    [SerializeField] private Image[] corazonesImages;

    [Header("Estadísticas")]
    public int monedas = 0;
    public int vidas = 3;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ActualizarUI();
    }

    public void SumarMonedas(int cantidad)
    {
        monedas += cantidad;
        ActualizarUI();
    }

    public void PerderVida()
    {
        vidas--;
        ActualizarUI();

        if (vidas <= 0)
        {
            GameOver();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void ActualizarUI()
    {
        if (monedaText != null)
        {
            monedaText.text = "x " + monedas;
        }

        for (int i = 0; i < corazonesImages.Length; i++)
        {
            if (corazonesImages[i] != null)
            {
                corazonesImages[i].gameObject.SetActive(i < vidas);
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over en Ultratumba");
        SceneManager.LoadScene("MainMenu");
    }
}