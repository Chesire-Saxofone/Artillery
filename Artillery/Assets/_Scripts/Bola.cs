using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameObject sonidoExplosion;
    private AudioSource SourceExplosion;

    private void Start()
    {
        sonidoExplosion = GameObject.Find("SonidoExplosion");
        SourceExplosion = sonidoExplosion.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Instancia partícula
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);

        // Reproduce sonido
        SourceExplosion.Play();

        // Destruye la bala
        Destroy(gameObject);
    }
}
