using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
   [SerializeField]
   private AudioSource BGMAudioSource, SFXAudioSource;
   public Sound[]  BGMSounds, SFXSounds;

   public void PlayBGM(string name)
   {
      Sound s = Array.Find(BGMSounds, Sound => Sound.name == name);

      if (s == null)
      {
         Debug.Log($"잘못된 사운드명 {name}");
      }
      else
      {
         BGMAudioSource.clip = s.clip;
         BGMAudioSource.Play(); 
      }
   }
   
   public void PlaySFX(string name)
   {
      Sound s = Array.Find(SFXSounds, Sound => Sound.name == name);

      if (s == null)
      {
         Debug.Log($"잘못된 사운드명 {name}");
      }
      else
      {
         SFXAudioSource.clip = s.clip;
         SFXAudioSource.Play(); 
      }
   }
}
   
   
