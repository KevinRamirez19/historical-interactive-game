using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo1 : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;
    public Animation Anim;
    public string NombreAnimacionCaminar;
    public string NombreAnimacionAtacar;
    public float Daño;
    void Start()
    {
       IA.speed = Velocidad;
       IA.SetDestination(Objetivo.position);

       if (IA.velocity == Vector3.zero)
       {
        Anim.CrossFade(NombreAnimacionAtacar);
       }
       else
       {
        Anim.CrossFade(NombreAnimacionCaminar);
       }
    }
   
    void Update()
    {
      Objetivo.GetComponent<Player_Move>().TakeDamage(Daño);
    }

    

}
