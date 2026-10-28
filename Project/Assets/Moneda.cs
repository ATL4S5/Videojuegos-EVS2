using UnityEngine;

public class Moneda : MonoBehaviour
{
    [Header("Configuración")]
    public int valorMoneda = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Debug.Log("¡Moneda recogida! + " + valorMoneda);

            Destroy(gameObject);
        }
    }
}