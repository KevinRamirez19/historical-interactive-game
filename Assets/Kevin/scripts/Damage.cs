using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int _damageAmount = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Move _player = collision.gameObject.GetComponent<Player_Move>();
            if (_player != null)
            {
                _player.TakeDamage(_damageAmount);
            }
        }
        
    }

   
    void Update()
    {
        
    }
}
