using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public Transform[] pickupPoints; // Puntos de recogida
    public Transform[] deliveryPoints; // Puntos de entrega
    private int currentPickupIndex = 0; // Índice del punto de recogida actual
    private int currentDeliveryIndex = 0; // Índice del punto de entrega actual

    void Start()
    {
        // Inicializa el juego o establece el primer objetivo
        Debug.Log("Misión iniciada: Recoger el mensaje en " + pickupPoints[currentPickupIndex].name);
    }

    public void OnMessagePickedUp()
    {
        // Al recoger el mensaje, avanzar al siguiente punto de entrega
        Debug.Log("Mensaje recogido en: " + pickupPoints[currentPickupIndex].name);
        currentPickupIndex++;

        if (currentPickupIndex < pickupPoints.Length)
        {
            Debug.Log("Llevar el mensaje a " + deliveryPoints[currentDeliveryIndex].name);
        }
        else
        {
            Debug.Log("Todos los mensajes recogidos. Llevar documento final a " + deliveryPoints[currentDeliveryIndex].name);
        }
    }

    public void OnMessageDelivered()
    {
        // Al entregar el mensaje, avanzar al siguiente punto de recogida
        Debug.Log("Mensaje entregado en: " + deliveryPoints[currentDeliveryIndex].name);
        currentDeliveryIndex++;

        if (currentDeliveryIndex < deliveryPoints.Length)
        {
            Debug.Log("Recoger el siguiente mensaje en " + pickupPoints[currentPickupIndex].name);
        }
        else
        {
            Debug.Log("Todas las entregas completadas. Misión finalizada.");
        }
    }
}
