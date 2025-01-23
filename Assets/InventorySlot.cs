using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
   public ItemData itemData;
   public Image ItemImage;
   public TextMeshProUGUI ItemCount;
   public int count = 0;


   public void AddItem(ItemData itemData)
   {
      if (this.itemData ==null)
      {
         this.itemData = itemData;
         this.ItemImage.sprite = itemData.icon;
         count++;
         ItemCount.text = count.ToString();
      }
      else
      {
         count++;
         ItemCount.text = count.ToString();
      }
   }

   
   
   
}
