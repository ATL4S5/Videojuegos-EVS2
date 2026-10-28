using UnityEngine;

public class TrampaDaño : MonoBehaviour
{
    [Header("Configuración de Trampa")]
    public int daño = 1;      
    public bool esInstaKill = false;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                if (esInstaKill)
                {
                    GameManager.Instance.vidas = 0;
                    GameManager.Instance.PerderVida();
                }
                else
                {
                    for (int i = 0; i < daño; i++)
                    {
                        GameManager.Instance.PerderVida();
                    }
                }
            }
        }
    }
}