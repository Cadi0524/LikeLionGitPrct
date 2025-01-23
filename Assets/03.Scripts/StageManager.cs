using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
   [SerializeField]
   private GameObject[] stageStartPoint;
   
   public Inventory inventory;
   public Item key;

   public GameObject Capsule;
   private Rigidbody rb;
   
   void Start()
   {
      rb = Capsule.GetComponent<Rigidbody>();
      
      StageSelect(0);
   }

  public void StageSelect(int stageIndex)
   {
      
      
      //위치 옮기고 앞을 바라보게 해줌 
      rb.transform.position = stageStartPoint[stageIndex].transform.position + new Vector3(0, 0.5f, 0);
      rb.transform.rotation = stageStartPoint[stageIndex].transform.rotation;
      
      
      // 여기다 UI 띄워야 함. -클리어시 UI야 ? 그럼 여기다 띄우면 안되지 멍청아.
      // 시작 UI면 인정임
      // 잠시동안 못움직이게 하든...   -- 이것도 코루틴이나 Unitask로 한 번에

      // 인벤창도 클리어 해줘야 함.  -removeInvenotry 호출
      
      
      //클리어 시 잠깐 있다가 소리 듣고 이동시키자. StageSelect로. 
      
      
      // 1스테이지일때는 자동으로 인벤토리에 열쇠 추가

      if (stageIndex == 0)
      {
         inventory.AddItemToInventory(key);
      }
      
   }
   
   
   
}
