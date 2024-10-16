using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public Transform[] pickupPoints; // Puntos de recogida
    public Transform[] deliveryPoints; // Puntos de entrega
    private int currentPickupIndex = 0; // Índice del punto de recogida actual
    private int currentDeliveryIndex = 0; // Índice del punto de entrega actual

    public MessageManager messageManager; // Referencia al MessageManager

    void Start()
    {
        StartMission(); // Comienza la misión
    }

    public void StartMission()
    {
        currentPickupIndex = 0;
        currentDeliveryIndex = 0;
        ShowMessage("Misión iniciada: Recoger el mensaje en " + pickupPoints[currentPickupIndex].name);
    }

    public void Restart()
    {
        StartMission(); // Reinicia la misión
    }

    public void OnMessagePickedUp()
    {
        // Al recoger el mensaje, avanzar al siguiente punto de entrega
        ShowMessage("Mensaje recogido en: " + pickupPoints[currentPickupIndex].name);
        currentPickupIndex++;

        if (currentPickupIndex < pickupPoints.Length)
        {
            ShowMessage("Llevar el mensaje a " + deliveryPoints[currentDeliveryIndex].name);
        }
        else
        {
            ShowMessage("Todos los mensajes recogidos. Llevar documento final a " + deliveryPoints[currentDeliveryIndex].name);
        }
    }

    public void OnMessageDelivered()
    {
        // Al entregar el mensaje, avanzar al siguiente punto de recogida
        ShowMessage("Mensaje entregado en: " + deliveryPoints[currentDeliveryIndex].name);
        currentDeliveryIndex++;

        if (currentDeliveryIndex < deliveryPoints.Length)
        {
            ShowMessage("Recoger el siguiente mensaje en " + pickupPoints[currentPickupIndex].name);
        }
        else
        {
            ShowMessage("Todas las entregas completadas. Misión finalizada.");
        }
    }

    private void ShowMessage(string message)
    {
        // Muestra el mensaje usando el MessageManager
        if (messageManager != null)
        {
            messageManager.ShowMessage(message);
        }
        else
        {
            Debug.LogWarning("MessageManager no está asignado en MissionManager.");
        }
    }
}
