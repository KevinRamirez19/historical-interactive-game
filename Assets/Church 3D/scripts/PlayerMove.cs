using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 7;
    public float rotationSpeed = 250;

public Animator animator;

private float x, y;

void Update()
{
    x = Input.GetAxis("Horizontal");

    y = Input.GetAxis("Vertical");

    transform.Rotate(0, x * Time.deltaTime *rotationSpeed, 0);
    transform.Translate(0, 0, Y * Time.deltaTime*runSpeed);
    animator.SetFloat("Velx" , x);
    animator.SetFloat("VelY", y);
}

}