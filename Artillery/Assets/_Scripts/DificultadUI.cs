using UnityEngine;
using TMPro; // <- necesario para TMP_Dropdown

public class DificultadUI : MonoBehaviour
{
    public TMP_Dropdown dropdown; 
    public Opciones opciones; 
    public AdministradorJuego adminJuego; 

    void Start()
    {
        dropdown.onValueChanged.AddListener(CambiarDificultad);
    }

    void CambiarDificultad(int index)
    {
        opciones.cambiarDificultad(index);
        adminJuego.DisparosPorJuegoPublico = opciones.cantidadBalas;
    }
}
