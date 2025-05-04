using UnityEngine;

public class Explosion : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Destroy(other.gameObject); // Elimina la pieza
            
        }
    }
}
