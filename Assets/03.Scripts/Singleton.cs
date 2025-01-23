using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
   private static T instance;

   public static T Instacne
   {
      get
      {
         if (instance == null)
         {
            instance = (T)FindObjectOfType(typeof(T));
            if (instance == null)
            {
               SetupInstance();
            }
         }
         return instance;
      }
   }


   public void Awake()
   {
      if (instance == null)
      {
         instance = this as T;
         DontDestroyOnLoad(this);
      }
      else
      {
         Destroy(this);
      }
   }

   private static void SetupInstance()
   {
      instance = (T)FindObjectOfType(typeof(T));
      if (instance == null)
      {
         GameObject gameObj = new GameObject();
         gameObj.name = typeof(T).Name;
         instance = gameObj.AddComponent<T>();
         DontDestroyOnLoad(gameObj);
      }
   }
   
   
}
