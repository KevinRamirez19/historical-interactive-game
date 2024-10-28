using UnityEngine;
using UnityEngine.UI;

public class ActivateCanvas : MonoBehaviour
{
    public Canvas canvasToActivate; // Canvas que se activará

    void Start()
    {
        // Asegúrate de que el canvas esté desactivado al inicio.
        canvasToActivate.gameObject.SetActive(false);
    }

    public void ActivateCanvasVisibility()
    {
        // Cambia la visibilidad del canvas al presionar el botón.
        canvasToActivate.gameObject.SetActive(true);
    }
}

