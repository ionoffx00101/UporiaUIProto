using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleFourControl : MonoBehaviour
{
    // left , bottom은 Negative 
    //  Input.GetAxis("Vertical") > 0 // gets forward
    // Input.GetAxis("Vertical") < 0 // gets backward
    // Input.GetAxis("Horizontal") > 0 // gets right
    // Input.GetAxis("Horizontal") < 0 // gets left

    private Vector3 inputVector;

    private void Awake ()
    {
        inputVector = new Vector3(0 , 0 , 0);
    }

    public void clickTop ()
    {
        Debug.Log("ㅇ");
        
    }
    public void clickLeft ()
    {
        Debug.Log("ㅇㅇ");
    }
    public void clickRight ()
    {
        Debug.Log("ㅇㅇㅇ");
    }
    public void clickBotton ()
    {
        Debug.Log("ㅇㅇㅇㅇ");
    }

    public float Horizontal ()
    {
        if ( inputVector.x != 0 )
        {
            return inputVector.x;
        }
        else
        {
            // Input의 Horizontal를 찾아서 반환
            return Input.GetAxis("Horizontal");
        }
    }
    public float Vertical ()
    {
        if ( inputVector.z != 0 )
        {
            return inputVector.z;
        }
        else
        {
            // Input의 Vertical 찾아서 반환
            return Input.GetAxis("Vertical");
        }
    }
}
