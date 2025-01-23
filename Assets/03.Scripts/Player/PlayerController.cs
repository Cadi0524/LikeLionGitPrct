using System;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMoveMent  playerMoveMent;

    // 컨트롤러에서 캐싱하는 것이 맞을듯 ? 
    // 지금은 무브먼트에서도 캐싱하고 있음
    private Rigidbody rb;
    
    
    public Inventory inventory;
    public Texture2D texture;
    
    
    private CursorRay playerCursor;

    private ClickableObject clickableObject;
    
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMoveMent = GetComponent<PlayerMoveMent>();
        playerCursor = GetComponent<CursorRay>();
        rb = GetComponent<Rigidbody>();
        clickableObject = GetComponent<ClickableObject>(); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
        Cursor.visible = false;
    }

    void Update()
    {
        // if (Cursor.lockState != CursorLockMode.Locked)
        // {
        //     Cursor.lockState = CursorLockMode.Locked;
        // }       
        playerMoveMent.Move(playerInput.moveInput);
        playerMoveMent.Look(playerInput.lookInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMoveMent.Jump(playerInput.jumpInput);
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.gameObject.activeInHierarchy)
            {
                inventory.gameObject.SetActive(false);
            }
            else
            {
                inventory.gameObject.SetActive(true);
            }
        }

        if (inventory.gameObject.activeInHierarchy)
        {
            inventory.HandleSelotSlection();
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (inventory.selectedSlot != null)
                {
                    inventory.RemoveSelectedItem(rb.transform.position);
                }
            }
        }
        
        playerCursor.CheckItem();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (playerCursor.Hit.collider == null) return;
            
                clickableObject.OnClick(playerCursor.Hit.point);
            
            
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerCursor.canPickUp)
            {
                inventory.AddItemToInventory(playerCursor.currentItem);
            }
            else if (playerCursor.canInteract)
            {
                //함수를 하나 호출해서 , 밑의 기능이 알아서 동작하게 해야 함.
                // 밑의 코드들은 지금 상호작용할 수 있는지 비교 > 상호작용/안함 > 상호작용 했으면 인벤토리에서 하나 깜
                // 그럼 함수 2개 호출 : 1 . 상호작용 관련 , 2. 인벤토리에서 Use함수 
                // 인벤토리에서 Use함수를 상호작용 이외에도 포션 등에 사용할 수 있을 것인가 ? 
                InteractiveItem interactiveItem = playerCursor.currentItem.GetComponent<InteractiveItem>();
                // 매개 변수로 받을 것 ,  아이템 데이터 받기  return할 것. bool 값
                if (inventory.selectedSlot.itemData == null) return;
                    //지금 처음 아이템 데이터가 할당 X 오류
                    interactiveItem.Interact(inventory.selectedSlot.itemData.ItemType);
                
                if (interactiveItem.interactComplete)
                { 
                   // interactiveItem.interactComplete = false; : 요거 지우면 재사용 가능, 불가능을 쓸 수 있음
                   //근데 재사용의 가부 여부를 여기서 판단하는 것은 옳지 않음.
                   inventory.ClearSlot(inventory.selectedSlot);
                }
                else
                {
                    Debug.Log("Can't interact with this item.");
                }
            }
        }
    }
}