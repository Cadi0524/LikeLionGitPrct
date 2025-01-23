using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// 도메인을 나누는 방식  : Ex) 인벤토리 ! 아이템 ! 

public class Inventory : MonoBehaviour
{
    public InventorySlot targetInventorySlot;

    public InventorySlot[] slots = new InventorySlot[20];
    // 슬롯이랑 데이터랑 매칭시켜야 할듯 ? 

    //이걸 int로 해서 그냥 몇 번째 인덱스인지 숫자만 넣어줘볼까
    //사용해야 훨씬 효율적일 것 같은데 . . . . 
    public Dictionary<ItemData, int> slotindex = new Dictionary<ItemData, int>();

    private int selectedSlotIndex = 0;
    public InventorySlot selectedSlot => slots[selectedSlotIndex];

    void Awake()
    {
        slots = GetComponentsInChildren<InventorySlot>();
    }

    public void HandleSelotSlection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSlot(4);
    }

    private void SelectSlot(int input)
    {
        if (0 <= input && input < 5)
        {
            selectedSlotIndex = input;
            Debug.Log($"Selected slot {selectedSlotIndex}");
        }
    }

    public InventorySlot FindingValidSlot(ItemData itemData)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemData == itemData)
            {
                Debug.Log("같은 아이템 들어옴");
                return slots[i];
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemData == null)
            {
                Debug.Log("i번째 슬롯이 비어있습니다");

                return slots[i];
            }
        }

        Debug.Log("모든 슬롯이 차 있습니다.");
        return null;
    }

    public void AddItemToInventory(Item item)
    {
        targetInventorySlot = FindingValidSlot(item.ItemData);

        if (targetInventorySlot != null)
        {
            targetInventorySlot.AddItem(item.ItemData);
            Destroy(item.gameObject);
        }
    }
    // if (playerCursor.canPickUp)
    // {
    //     inventory.targetInventorySlot = inventory.FindingValidSlot(playerCursor.currentItem.ItemData);
    //     if (inventory.targetInventorySlot != null)
    //     {
    //         inventory.AddItemToInventory(playerCursor.currentItem.ItemData);
    //         playerCursor.PickUpItem();
    //     }
    //     else
    //     {
    //         Debug.Log("아이템창이 꽉 차서 주울 수 없습니다.");
    //     }


    // 슬롯이 어쩌피 선택되는 것이 같은 클래스인 inventory에 있음
    public void RemoveSelectedItem(Vector3 position)
    {
        if (selectedSlot != null)
        {
            //전 코드 기억하기. 
            ItemManager.Instacne.SpawnItem(selectedSlot.itemData, position);

            ClearSlot(selectedSlot);
        }
    }
    //이름이 뭔가 이상함 ,위 코드까지 정리 완료
    public void ClearSlot(InventorySlot slot)
    {
        slot.count--;
        if (slot.count == 0)
        {
            slot.itemData = null;
            slot.ItemImage.sprite = null;
        }
        slot.ItemCount.text = slot.count.ToString();
    }
}