using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo1 : MonoBehaviour
{
  public GameObject _personaje;
  public float _distance, _throwingForce = 20f, _agroDistance = 3f;
  public Vector3 _direction;
  public GameObject _trash;
  public Transform _initialPositionTrash;
  public float _timeThrowing = 3f;
  public Animator _animator;
  public bool _hasLaunched;
  public int _loopCicleAnimation = 0;
  void Start()
  {
    _animator = GetComponent<Animator>();
    _personaje = GameObject.FindGameObjectWithTag("Player");

  }

  void Update()
  {
    _distance = Vector3.Distance(transform.position, _personaje.transform.position);
    _direction = new Vector3(_personaje.transform.position.x, _personaje.transform.position.y, _personaje.transform.position.z);
    transform.LookAt(_direction);
    if (_distance <= _agroDistance)
    {
      _animator.SetBool("Throw", true);
      monitorAnimation();
    }
    else
    {
      _loopCicleAnimation = 0;
      _animator.SetBool("Throw", false);
      _hasLaunched = false;
    }
  }
  public void throwingTrash()
  {
    GameObject _cube = Instantiate(_trash, _initialPositionTrash.position, Quaternion.identity);
    Rigidbody _rb = _cube.GetComponent<Rigidbody>();
    if (_rb != null)
    {
      _cube.transform.LookAt(_direction);
      _rb.AddForce(_initialPositionTrash.forward * _throwingForce, ForceMode.Impulse);
    }
  }
  public void monitorAnimation()
  {

    AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
    if (state.IsName("Throw Object"))
    {
      int _newCicleAnimation = Mathf.FloorToInt(state.normalizedTime);
      if (_newCicleAnimation > _loopCicleAnimation)
      {
        _loopCicleAnimation= _newCicleAnimation;
        _hasLaunched = false;
      }
    if (state.normalizedTime %1 >= 0.5f && !_hasLaunched)
    {
      throwingTrash();
      _hasLaunched = true;
    }
    }
  }
}
