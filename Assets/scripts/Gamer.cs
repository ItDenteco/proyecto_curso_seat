using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct Pregunta
{
    public string enunciado;
    public string nombrePlaneta;
}

public class Gamer : MonoBehaviour
{

    [Header("Preguntas...")]
    public List<Pregunta> preguntas = new List<Pregunta> ();
    private Pregunta preguntaActual;
    private bool juegoTerminado = false;

    void  Start() {

        if (preguntas.Count == 0) {

            preguntas.Add(new Pregunta { enunciado = "¿Cual es el planeta mas grande del sistems solar?", nombrePlaneta = "jupiter" });
            preguntas.Add(new Pregunta { enunciado = "¿Cual es el planeta rojo?", nombrePlaneta = "marte" });
            preguntas.Add(new Pregunta { enunciado = "¿En que planeta vivimos?", nombrePlaneta = "tierra" });
            preguntas.Add(new Pregunta { enunciado = "¿Que planeta tiene anillos?", nombrePlaneta = "saturno" });
        }
        GenerarNuevaPregunta();

    }
    public void GenerarNuevaPregunta()
    {
        if (preguntas.Count == 0) {
            Debug.Log("Has respondido todas las pregunta!!!");
            juegoTerminado = true;
            return;
        }
        int indexAleatorio = Random.Range(0, preguntas.Count);
        preguntaActual = preguntas[indexAleatorio];

        Debug.Log("---------------------------------------");
        Debug.Log($"-Pregunta: {preguntaActual.enunciado}-");
        Debug.Log("Debes enfocar la respuesta en tu camara");
        Debug.Log("---------------------------------------");
    }
    public void ValidarRespuesta(string nombreTargetaDetectado)
    {
        if (juegoTerminado) return;
        if (nombreTargetaDetectado == preguntaActual.nombrePlaneta)
        {
            Debug.Log("Haz enfocado la targeta correcta!!!");
            preguntas.Remove(preguntaActual);
            GenerarNuevaPregunta();
        }
        else
        {
            Debug.Log("INCORRECTO: Enfocaste otra pregunta");
        }
    }
}