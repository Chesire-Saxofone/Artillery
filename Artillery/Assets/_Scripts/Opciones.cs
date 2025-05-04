using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Opciones", menuName ="Herramientas/Opciones",order = 1)]
public class Opciones : ScriptableObject
{
    public int cantidadBalas;
    public dificultad NivelDificultad = dificultad.facil;

    public enum dificultad
    {
        facil,
        normal,
        dificil
    }

    public void cambiarDificultad(int NuevaDificultad)
    {
        NivelDificultad = (dificultad)NuevaDificultad;

        switch (NivelDificultad)
        {
            case dificultad.facil:
                cantidadBalas = 15;
                break;
            case dificultad.normal:
                cantidadBalas = 10;
                break;
            case dificultad.dificil:
                cantidadBalas = 6;
                break;
        }

        Debug.Log("Dificultad cambiada a: " + NivelDificultad + " | Balas: " + cantidadBalas);
    }
}
