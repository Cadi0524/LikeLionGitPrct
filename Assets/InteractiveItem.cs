using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : Item
{
    // 무조건 고정이 되었으니 일단은 넘어가지만,
    // 만일 확장을 해야한다면 ? 
    
    public ItemType interactiveItemType;
    public bool interactComplete = false;
    public GameObject targetObject;
    private Animator animator;
    [SerializeField]
    private Animator targetAnimator;

    

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        targetAnimator = targetObject.GetComponent<Animator>();
    }

    // itemType 으로 비교 왜 ? string값으로 비교하는건 너무 비쌈.
    public void Interact(ItemType itemType)
    {
        if (itemType == ItemType.None) return;

        //재사용 가부 판단을 어떻게 해야 할까 ?
        if (itemType == interactiveItemType && interactComplete == false)
        {
            interactComplete = true;

            // 함정은 어떤 행위가 실행되었을 때 자신이 실행되는 것  : 옵저버 패턴 
            // 발동되어야 할 이벤트 구독 
            // 어떤 경우 collider, interact가 되었을 떄도 있는 경우
            // 구현할 때 경우의 수를 한 가지만 두지는 말아라 
            // 자기가 당하는건지 실행하는건지도 중요하다. 

            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger("Interact");
            }
        }
        else
        {
            Debug.Log("Wrong interactive item name");
            interactComplete = false;
        }
    }
}