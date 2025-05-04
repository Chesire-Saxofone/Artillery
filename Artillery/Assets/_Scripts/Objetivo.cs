using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Objetivo : MonoBehaviour
{
    public UnityEvent GameWon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            GameWon.Invoke();
            Destroy(gameObject);
        }
    }
}
