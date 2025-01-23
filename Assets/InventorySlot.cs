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
         Debug.Log($"아이템슬롯에 아이콘 :{this.itemData.icon} ");
         count++;
         ItemCount.text = count.ToString();
      }
      else
      {
         count++;
         ItemCount.text = count.ToString();
         Debug.Log($"아이템이 {count}개 되었습니다");
      }
   }

   
   
   
}
