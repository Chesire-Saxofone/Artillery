using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReinicio : MonoBehaviour
{
 
    public void reintentarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
