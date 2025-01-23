using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CursorRay : MonoBehaviour
{
    RaycastHit hit;
    public Item currentItem;
    public TextMeshProUGUI textMesh;
    public bool canPickUp = false;
    public bool canInteract = false;
    
    
    public RaycastHit Hit => hit;

    

    public void CheckItem()
    {
        if (Physics.Raycast(Camera.main.transform.position,
                Camera.main.transform.forward, out hit, 5f))
        {
            
            //아무것도 닿지 않으면  무시
            if (hit.collider == null) return;
           if(hit.collider.gameObject.layer == LayerMask.NameToLayer("item"))
            {
                Item raycastedItem = hit.transform.GetComponent<Item>();
                if (currentItem == raycastedItem) return;
                currentItem = raycastedItem;
                itemInfoApper(raycastedItem);
            }
           //태그로 아이템을 확장 시 제한이 있을 수 있음.
           // interface를 보통 사용함
           // 일단 Layer로 ...  . .. . compareTag는 문자열 비교 or Hash로 비교함
           // layer은 bit 비교라 훨씬 쌈
           else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("interactable"))
           {
               textMesh.text = "Interactive object";
               Item raycastedItem = hit.transform.GetComponent<Item>();
               if (currentItem == raycastedItem) return;
               currentItem = raycastedItem;               
               textMesh.gameObject.SetActive(true);
               canInteract = true;
           }
            //닿은 물체의 tag가 item이 아니면 정보 OFF
            else itemInfoDisappaer();
        }
        // 아무것도 닿지 않으면 정보 OFF
        else itemInfoDisappaer();
    }

  
    private void itemInfoDisappaer()
    {
        currentItem = null;
        textMesh.gameObject.SetActive(false);
        canPickUp = false;
        canInteract = false;
    }


    private void itemInfoApper(Item raycastedItem)
    {
        textMesh.text = raycastedItem.ItemData.ItemName;
       textMesh.gameObject.SetActive(true);
       canPickUp = true;
    }

   

}