using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa;
    public GameObject menuOpciones;

    public void mostrarMenuPausa()
    {
        menuPausa.SetActive(true);
        if (menuOpciones.activeInHierarchy)
        {
            menuOpciones.SetActive(false);
        }
    }

    public void ocultarMenuPausa()
    {
        menuPausa.SetActive(false);
    }

    public void regresarPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void mostaraMenuOpciones()
    {
        menuOpciones.SetActive(true);
        if (menuPausa.activeInHierarchy)
        {
            menuPausa.SetActive(false);
        }
    }
}
