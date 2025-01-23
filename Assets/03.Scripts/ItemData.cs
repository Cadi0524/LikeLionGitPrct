using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
   None,
   Sword,
   Potion,
   Key,
   Max
}


[CreateAssetMenu(fileName = "Item", menuName ="Item/ItemData")]
public class ItemData : ScriptableObject
{
   [SerializeField] private string itemName;
   

   public string ItemName => itemName;
   public ItemType ItemType;
   public Sprite icon;
   public GameObject itemprefab;
   public string comparetag;
   

}
