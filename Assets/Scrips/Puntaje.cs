using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public float Puntos { get; private set; }  // Propiedad pública de solo lectura para acceder a los puntos
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        // Verificación para asegurar que textMesh no es null
        if (textMesh == null)
        {
            Debug.LogError("No se encontró el componente TextMeshProUGUI en el objeto Puntaje.");
        }
    }

    private void Update()
    {
        if (textMesh != null)
        {
            textMesh.text = Puntos.ToString("0");
        }
    }

    public void sumarPuntos(float puntosEntrada)
    {
        Puntos += puntosEntrada;
    }
}
