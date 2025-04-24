using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  

public class Canon : MonoBehaviour
{
    public static bool bloqueado;

    public AudioClip clipDisparo;   
    private GameObject sonidoDisparo;
    private AudioSource SourceDisparo;

    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCanon;
    public GameObject ParticulasDisparo;
    private GameObject adminJuego;
    private float rotacion;
    private int disparos;
    private AdministradorJuego admin;

    public CanonControles canonControles;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    private void Awake()
    {
        canonControles = new CanonControles();
    }

    private void OnEnable()
    {
        apuntar = canonControles.Canon.Apuntar;
        apuntar.Enable();
        modificarFuerza = canonControles.Canon.ModificarFuerza;
        modificarFuerza.Enable();
        disparar = canonControles.Canon.Disparar;
        disparar.Enable();
        disparar.performed += Disparar;

    }

    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;

        sonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = sonidoDisparo.GetComponent<AudioSource>();

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

        rotacion += apuntar.ReadValue<float>() * admin.VelocidadRotacionPublico;
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

       
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
        //GameObject Particulas = Instantiate(ParticulasDisparo, puntaCanon.transform.position, transform.rotation);
        Rigidbody tempRB = temp.GetComponent<Rigidbody>();
        SeguirCamara.objetivo = temp;
        Vector3 direccionDisparo = transform.rotation.eulerAngles;
        direccionDisparo.y = 90 - direccionDisparo.x;
        Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
        GameObject Particulas = Instantiate(ParticulasDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
        tempRB.linearVelocity = direccionDisparo.normalized * admin.VelocidadBolaPublico;
        SourceDisparo.Play();
        disparos--;
        bloqueado = true;
    }
}
