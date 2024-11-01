using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MissionBB : MonoBehaviour
{
    public GameObject[] objetos; // Arreglo de objetos a recoger
    public GameObject finalZone; // Zona final
    public Text mensajeUI; // Referencia al texto del canvas para mostrar mensajes
    public float duracionMensaje = 20f; // Duración del mensaje en pantalla

    private int objetoRecogidoIndex = 0; // Índice del objeto actualmente recogido

    private void Start()
    {
        // Desactivar todos los objetos excepto el primero en la secuencia
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(i == 0); // Solo el primer objeto está activo
        }

        // Desactivar la zona final al inicio
        finalZone.SetActive(false);
    }

    public void RecogerObjeto(GameObject objeto)
    {
        // Asegurarse de que el índice actual está dentro del rango
        if (objetoRecogidoIndex < objetos.Length && objeto == objetos[objetoRecogidoIndex])
        {
            // Mostrar el mensaje asociado al objeto y ocultarlo tras una duración específica
            mensajeUI.text = objeto.GetComponent<Objeto>().mensaje;
            StartCoroutine(OcultarMensaje());

            // Desactivar el objeto recogido
            objeto.SetActive(false);

            // Incrementar el índice para el siguiente objeto
            objetoRecogidoIndex++;

            // Activar el siguiente objeto si está dentro del rango
            if (objetoRecogidoIndex < objetos.Length)
            {
                objetos[objetoRecogidoIndex].SetActive(true);
            }
            else
            {
                // Si se han recogido todos los objetos, activar la zona final
                finalZone.SetActive(true);
                mensajeUI.text = "¡Has recogido todos los objetos!";
            }
        }
        else
        {
            // Mensaje temporal de error si el jugador intenta recoger un objeto fuera de orden
            mensajeUI.text = "Recoge el objeto correcto primero.";
            StartCoroutine(OcultarMensaje());
        }
    }

    // Coroutine para ocultar el mensaje tras una duración especificada
    private IEnumerator OcultarMensaje()
    {
        yield return new WaitForSeconds(duracionMensaje);
        mensajeUI.text = ""; // Limpia el mensaje después del tiempo especificado
    }
}
