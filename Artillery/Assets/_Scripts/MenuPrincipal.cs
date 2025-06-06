using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public GameObject MenuOpciones;
    public GameObject MenuInicial;

    public void IniciarJuego()
    { 
        SceneManager.LoadScene(1);
    }

    public void FinalizarJuego()
    { 
    Application.Quit();
    }

    public void MostrarMenuOpciones()
    {
        MenuOpciones.SetActive(true);
        MenuInicial.SetActive(false);
    }

    public void MostrarMenuInicial()
    {
        MenuOpciones.SetActive(false);
        MenuInicial.SetActive(true);
    }
}
