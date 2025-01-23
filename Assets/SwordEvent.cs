using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEvent : MonoBehaviour
{
  public GameObject Sword;
  //
  
  void SwordEventMethod()
  {
    Sword.SetActive(true);
  }
}
