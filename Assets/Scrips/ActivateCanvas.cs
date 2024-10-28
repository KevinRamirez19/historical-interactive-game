using UnityEngine;
using UnityEngine.UI;

public class ActivateCanvas : MonoBehaviour
{
    public Canvas canvasToActivate; // Canvas que se activar�

    void Start()
    {
        // Aseg�rate de que el canvas est� desactivado al inicio.
        canvasToActivate.gameObject.SetActive(false);
    }

    public void ActivateCanvasVisibility()
    {
        // Cambia la visibilidad del canvas al presionar el bot�n.
        canvasToActivate.gameObject.SetActive(true);
    }
}

