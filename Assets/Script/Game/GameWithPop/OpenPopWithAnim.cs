using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenPopWithAnim : MonoBehaviour {

    public Image popupPanel;

    //public Animation popupAnim;
    private AnimationClip popupClip;
    public Canvas canvas;

    private void Start ()
    {
        //popupAnim = GetComponent<Animation>();

        popupClip = GetComponent<AnimationClip>();
    }

    public void openPop ()
    {
        if ( popupPanel.IsActive() )
        {
            
            //popupAnim.Play("Popup");
        }
        else
        {
            //popupAnim.Play("popdown");
        }
        popupPanel.gameObject.SetActive(!popupPanel.IsActive());

    }
}
