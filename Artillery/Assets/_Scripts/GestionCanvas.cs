using UnityEngine;
using TMPro;
using System.Collections;   
using System.Collections.Generic;

public class GestionCanvas : MonoBehaviour
{

    public Transform BalasRestantes;
    public TMP_Text Balas;
    public int balas;
    public Canon referenciaCanon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BalasRestantes = GameObject.Find("Balas Restantes").transform;
        Balas = BalasRestantes.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Balas.text = referenciaCanon.disparos.ToString();
    }
}
