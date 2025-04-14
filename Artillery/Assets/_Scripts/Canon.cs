using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    

    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCanon;
    private GameObject adminJuego;
    private float rotacion;
    private int disparos;
    private AdministradorJuego admin;


    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;

        admin = AdministradorJuego.ObtenerInstancia();

        if (admin != null)
        {
            disparos = admin.DisparosPorJuegoPublico;
            rotacion = 0;
        }
        else
        {
            Debug.LogError("No se pudo obtener la instancia del AdministradorJuego");
        }

    }   
    // Update is called once per frame
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * admin.VelocidadRotacionPublico;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90.0f, 0.0f);
        }

        if (rotacion > 90)
        {
            rotacion = 90;
        }
        else if (rotacion < 0)
        {
            rotacion = 0;
        }

        if (disparos > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                Vector3 direccionDisparo = transform.rotation.eulerAngles;
                direccionDisparo.y = 90 - direccionDisparo.x;
                tempRB.linearVelocity = direccionDisparo.normalized * admin.VelocidadBolaPublico;
                disparos--;
            }
        }
    }
}
