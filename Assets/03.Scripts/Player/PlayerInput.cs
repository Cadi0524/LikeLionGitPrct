using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
  public UnityEngine.InputSystem.PlayerInput playerInput;
    
  public Vector2 moveInput;
  public Vector2 lookInput;
  public bool jumpInput;
  
  
  void Start()
  {
     playerInput = GetComponent<UnityEngine.InputSystem.PlayerInput>();
 
  }

  void Update()
  {
      moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
      lookInput = playerInput.actions["Look"].ReadValue<Vector2>();
      jumpInput = playerInput.actions["Jump"].triggered;
  }
}