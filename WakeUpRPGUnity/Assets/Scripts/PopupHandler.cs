/**
 * Created By: Aidan Pohl
 * Created On: Jan 19, 2023
 * 
 * Edited By: Aidan Pohl
 * Edited: Jan 20, 2023
 * 
 * Description: Handler for Popup windows during gameplay
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupHandler : MonoBehaviour
{
    ///VARIABLES///
    public GameObject PopupObject;
    public GameObject PopupCloseButton;
    public GameObject PopupOpenButton;

    public void PopupOpen()
    {
        PopupObject.SetActive(true);
        PopupCloseButton.SetActive(true);
        PopupOpenButton.SetActive(false);
    }

    public void PopupClose()
    {
        PopupObject.SetActive(false);
        PopupCloseButton.SetActive(false);
        PopupOpenButton.SetActive(true);
    }
}
