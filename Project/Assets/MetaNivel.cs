using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaNivel : MonoBehaviour
{
    [Header("Configuración de Victoria")]
    [SerializeField] private string nombreSiguienteNivel = "Nivel2";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreSiguienteNivel);
        }
    }
}