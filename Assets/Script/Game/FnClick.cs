using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FnClick : MonoBehaviour {

    //버튼 클릭 확인하는 스크립트
    public void ClickA ()
    {
        Debug.Log("A");
    }

    public void ClickB ()
    {
        // insertScoreManager 에서도 이 버튼클릭으로 호출되는 메서드가 있다.
        Debug.Log("B");
    }
}
