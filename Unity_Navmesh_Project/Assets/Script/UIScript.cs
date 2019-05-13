using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScript : MonoBehaviour
{
    public RectTransform buttonsPanel;
    public Button triggerButton;

    bool isOpened = false;

    public void TriggerButtonsPanel()
    {
        if(isOpened){
            buttonsPanel.DOAnchorPosX(230, 1);
            triggerButton.GetComponentInChildren<Text>().text = "<";
        }else{
            buttonsPanel.DOAnchorPosX(0, 1);
            triggerButton.GetComponentInChildren<Text>().text = ">";
        }
        isOpened = !isOpened;
    }

}
