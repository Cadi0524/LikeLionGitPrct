using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stageIndex;
    private Animator animator;
    public float duration;

    
    public IEnumerator TransitionToNextStage(int stageIndex)
    {
        Debug.Log("들어옴");
        yield return new WaitForSeconds(duration);
        Debug.Log("대기 끝");
        StageManager.Instacne.StageSelect(stageIndex);
        Debug.Log("이동 끝");
    }
    

}
