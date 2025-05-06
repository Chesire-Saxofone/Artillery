using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AdministradorJuego : MonoBehaviour
{
    private static AdministradorJuego SingletonAdministradorJuego;
    private static int VelocidadBola = 30;
    private static int DisparosPorJuego = 10;
    private static float VelocidadRotacion = 1;
    public Canon contador;
    public Opciones opciones;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;
    public GameObject BotonReiniciar;

    public int VelocidadBolaPublico
    {
        get { return VelocidadBola; }
        set { VelocidadBola = value; }
    }
    public int DisparosPorJuegoPublico
    {
        get { return DisparosPorJuego; }
        set { DisparosPorJuego = value; }
    }
    public float VelocidadRotacionPublico
    {
        get { return VelocidadRotacion; }
        set { VelocidadRotacion = value; }
    }
    public static AdministradorJuego ObtenerInstancia()
    {
        return SingletonAdministradorJuego;
    }
    private void Awake()
    {
        DisparosPorJuegoPublico = opciones.cantidadBalas;
        if (SingletonAdministradorJuego == null)
            {
            SingletonAdministradorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de AdministradorJuego");
        }
    }

    private void Update()
    {
        if (contador.disparos <= 0 && Canon.bloqueado == false && !CanvasGanar.activeSelf)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    { 
        CanvasGanar.SetActive(true);
        contador.disparos = 0;
    }
    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
        BotonReiniciar.SetActive(true);
    }
}
