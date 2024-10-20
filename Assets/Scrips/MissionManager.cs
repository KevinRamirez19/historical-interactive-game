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
        InitializeMission(); // Inicializa la misión
    }

    private void InitializeMission()
    {
        // Desactiva todos los puntos de recogida y entrega
        DeactivateAllPickupPoints();
        DeactivateAllDeliveryPoints();

        // Comienza la misión
        StartMission();
    }

    private void StartMission()
    {
        currentPickupIndex = 0;
        currentDeliveryIndex = 0;

        // Activa el primer punto de recogida
        ActivatePickupPoint(currentPickupIndex);
        ShowMessage("Misión iniciada: Recoger el mensaje en " + pickupPoints[currentPickupIndex].name);
    }

    private void DeactivateAllPickupPoints()
    {
        foreach (Transform pickupPoint in pickupPoints)
        {
            pickupPoint.gameObject.SetActive(false); // Desactiva cada punto de recogida
        }
    }

    private void DeactivateAllDeliveryPoints()
    {
        foreach (Transform deliveryPoint in deliveryPoints)
        {
            deliveryPoint.gameObject.SetActive(false); // Desactiva cada punto de entrega
        }
    }

    public bool CanPickup(int pickupIndex)
    {
        // Verifica si el índice de recogida coincide con el índice actual
        return pickupIndex == currentPickupIndex;
    }

    public void OnMessagePickedUp()
    {
        ShowMessage("Mensaje recogido en: " + pickupPoints[currentPickupIndex].name);
        DeactivatePickupPoint(currentPickupIndex);
        currentPickupIndex++;

        // Si no es el último mensaje, continúa con los siguientes puntos de entrega
        if (currentPickupIndex < pickupPoints.Length)
        {
            ActivateDeliveryPoint(currentDeliveryIndex);
            ShowMessage("Llevar el mensaje a " + deliveryPoints[currentDeliveryIndex].name);
        }
        else
        {
            // Cuando todos los mensajes han sido recogidos, activa el punto de entrega final
            if (currentDeliveryIndex < deliveryPoints.Length)
            {
                ActivateDeliveryPoint(currentDeliveryIndex); // Activa el último punto de entrega
                ShowMessage("Todos los mensajes recogidos. Llevar documento final a " + deliveryPoints[currentDeliveryIndex].name);
            }
        }
    }


    public void OnMessageDelivered()
    {
        ShowMessage("Mensaje entregado en: " + deliveryPoints[currentDeliveryIndex].name);
        DeactivateDeliveryPoint(currentDeliveryIndex);
        currentDeliveryIndex++;

        // Verificar si aún quedan más puntos de entrega
        if (currentDeliveryIndex < deliveryPoints.Length)
        {
            ActivatePickupPoint(currentPickupIndex);
            ShowMessage("Recoger el siguiente mensaje en " + pickupPoints[currentPickupIndex].name);
        }
        else
        {
            // Si llegamos aquí, la última entrega ha sido completada
            ShowMessage("Todas las entregas completadas. Misión finalizada.");
            ShowFinalMessage(); // Muestra mensaje de fin del juego
        }
    }


    public void Restart()
    {
        // Reinicia la misión
        InitializeMission();
    }

    private void ActivatePickupPoint(int index)
    {
        if (index < pickupPoints.Length)
        {
            pickupPoints[index].gameObject.SetActive(true);
        }
    }

    private void DeactivatePickupPoint(int index)
    {
        if (index < pickupPoints.Length)
        {
            pickupPoints[index].gameObject.SetActive(false);
        }
    }

    private void ActivateDeliveryPoint(int index)
    {
        if (index < deliveryPoints.Length)
        {
            deliveryPoints[index].gameObject.SetActive(true);
        }
    }

    private void DeactivateDeliveryPoint(int index)
    {
        if (index < deliveryPoints.Length)
        {
            deliveryPoints[index].gameObject.SetActive(false);
        }
    }

    private void ShowFinalMessage()
    {
        messageManager.ShowMessage("Juego Finalizado"); // Mensaje final
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
