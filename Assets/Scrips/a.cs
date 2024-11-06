using UnityEngine;

public class ControlDeEntrada : MonoBehaviour
{
    public float fuerzaEmpuje = 10f; // Fuerza con la que se empujará al enemigo

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Solo permite la entrada al "Player"
            Debug.Log("Player ha entrado en el área permitida.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            // Empuja al enemigo para que no pueda quedarse en el área
            Rigidbody enemigoRb = other.GetComponent<Rigidbody>();

            if (enemigoRb != null)
            {
                Vector3 direccionEmpuje = (other.transform.position - transform.position).normalized;
                enemigoRb.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);

                Debug.Log("Enemigo detectado y empujado fuera del área.");
            }
        }
        else if (!other.CompareTag("Player"))
        {
            // Bloquea la entrada a cualquier objeto que no sea "Player" o "Enemigo"
            Debug.Log("Objeto no permitido intentó entrar.");
        }
    }
}
