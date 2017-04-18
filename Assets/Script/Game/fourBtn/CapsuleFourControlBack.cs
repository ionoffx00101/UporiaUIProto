using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CapsuleFourControlBack : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    // left , bottom은 Negative 
    //  Input.GetAxis("Vertical") > 0 // gets forward
    // Input.GetAxis("Vertical") < 0 // gets backward
    // Input.GetAxis("Horizontal") > 0 // gets right
    // Input.GetAxis("Horizontal") < 0 // gets left

    // input.negative btn
    // 눌린다 이미지
    // 뭔이미지가 눌리는지 확인하고
    // 해당 하는거마다 스크립트를 작성해준다
    // 그러면되나

    private Image bigStick;
    //
    private Image topBtn;
    private Image bottomBtn;
    private Image leftBtn;
    private Image rightBtn;
    //
    private Vector3 inputVector;
    //
    private int x;

    private void Awake ()
    {

    }
    private void Start ()
    {
        x = 0;
        //
        bigStick = GetComponent<Image>();

        topBtn = transform.GetChild(0).GetComponent<Image>();
        leftBtn = transform.GetChild(1).GetComponent<Image>();
        rightBtn = transform.GetChild(2).GetComponent<Image>();
        bottomBtn = transform.GetChild(3).GetComponent<Image>();
    }

    public virtual void OnPointerDown (PointerEventData ped)
    {
        // 누르는 경우는 드래그 메소드로 값을 보냄
        OnDrag(ped);
    }
    public virtual void OnPointerUp (PointerEventData ped)
    {
        // 손 떼면 위치 초기화
        inputVector = Vector3.zero;
    }
    public virtual void OnDrag (PointerEventData ped)
    {
        //Input.GetAxis
        
        if(ped.position.x == topBtn.transform.position.x )
        {
            Debug.Log("ttt"+x++);
        }
    }
    //public void clickTop ()
    //{
    //    Debug.Log("ㅇ");

    //}
    //public void clickLeft ()
    //{
    //    Debug.Log("ㅇㅇ");
    //}
    //public void clickRight ()
    //{
    //    Debug.Log("ㅇㅇㅇ");
    //}
    //public void clickBotton ()
    //{
    //    Debug.Log("ㅇㅇㅇㅇ");
    //}

    //public float Horizontal ()
    //{
    //    if ( inputVector.x != 0 )
    //    {
    //        return inputVector.x;
    //    }
    //    else
    //    {
    //        // Input의 Horizontal를 찾아서 반환
    //        return Input.GetAxis("Horizontal");
    //    }
    //}
    //public float Vertical ()
    //{
    //    if ( inputVector.z != 0 )
    //    {
    //        return inputVector.z;
    //    }
    //    else
    //    {
    //        // Input의 Vertical 찾아서 반환
    //        return Input.GetAxis("Vertical");
    //    }
    //}
}
