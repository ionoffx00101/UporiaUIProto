using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CapsuleFourControl : MonoBehaviour //, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public float distanceControl = 1f;
    private Vector3 inputVector;

    private void Awake ()
    {
        inputVector = new Vector3(0,0,0);
    }
    public void clickTop ()
    {
        inputVector = new Vector3(0,0, distanceControl);
      
    }
    public void clickLeft ()
    {
        inputVector = new Vector3(-distanceControl , 0 , 0);
       
    }
    public void clickRight ()
    {
        inputVector = new Vector3(distanceControl , 0 , 0);
       
    }
    public void clickBottom ()
    {
        inputVector = new Vector3(0 , 0 , -distanceControl);
  
    }

    public float Horizontal ()
    {
        Vector3 saveVector = new Vector3(0 , 0 , 0); //
        if ( inputVector.x != 0 )
        {
            saveVector = inputVector; //
            inputVector = Vector3.zero; //
            return saveVector.x;
        }
        else
        {
            // Input의 Horizontal를 찾아서 반환
            return Input.GetAxis("Horizontal");
        }
    }
    public float Vertical ()
    {
        Vector3 saveVector = new Vector3(0 , 0 , 0); //
        if ( inputVector.z != 0 )
        {
            saveVector = inputVector; //
            inputVector = Vector3.zero; //
            return saveVector.z;
        }
        else
        {
            // Input의 Vertical 찾아서 반환
            return Input.GetAxis("Vertical");
        }
    }
}
