using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum STATES{
 IDLE,
 WALK
}
public class States_Obstacles : MonoBehaviour
{
    public Animator _animator;
    private STATES _state;

    // Start is called before the first frame update
    void Start()
    {
         _animator = GetComponent<Animator>();
         _state = STATES.IDLE;  
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.H))
       {
        _animator.SetBool("Caminando", true);

       }
       if(Input.GetKeyUp(KeyCode.H))
       {
        _animator.SetBool("Caminando", false);
       }
          
        
    }
}
