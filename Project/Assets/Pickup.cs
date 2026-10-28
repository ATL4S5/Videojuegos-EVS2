using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private int valorMoneda = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SumarMonedas(valorMoneda);
            }
            
            Destroy(gameObject);
        }
    }
}