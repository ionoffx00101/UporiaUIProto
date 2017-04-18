using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenPopWithoutAnim : MonoBehaviour {

    public Image popupPanel;

    public void openPop ()
    {
        //popupPanel.enabled = true;
        //popupPanel.GetComponent<Image>().enabled = true;
        //popupPanel.gameObject.active = !popupPanel.gameObject.active;

        popupPanel.gameObject.SetActive(!popupPanel.IsActive());

        //Debug.Log(popupPanel.IsActive());
    }
}
