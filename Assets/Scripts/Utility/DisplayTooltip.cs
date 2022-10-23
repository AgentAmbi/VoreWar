﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int value;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (State.GameManager.Menu.ContentSettings.gameObject.activeSelf)
            State.GameManager.Menu.ContentSettings.ChangeToolTip(value);
        else if (State.GameManager.Menu.Options.gameObject.activeSelf)
            State.GameManager.Menu.Options.ChangeToolTip(value);
        else if (State.GameManager.Start_Mode.CreateStrategicGame.gameObject.activeSelf)
            State.GameManager.Start_Mode.CreateStrategicGame.ChangeToolTip(value);
        else if (State.GameManager.Start_Mode.CreateTacticalGame.gameObject.activeSelf)
            State.GameManager.Start_Mode.CreateTacticalGame.ChangeToolTip(value);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (State.GameManager.Menu.ContentSettings.gameObject.activeSelf)
            State.GameManager.Menu.ContentSettings.ChangeToolTip(0);
        else if (State.GameManager.Menu.Options.gameObject.activeSelf)
            State.GameManager.Menu.Options.ChangeToolTip(0);
        else if (State.GameManager.Start_Mode.CreateStrategicGame.gameObject.activeSelf)
            State.GameManager.Start_Mode.CreateStrategicGame.ChangeToolTip(0);
        else if (State.GameManager.Start_Mode.CreateTacticalGame.gameObject.activeSelf)
            State.GameManager.Start_Mode.CreateTacticalGame.ChangeToolTip(0);
        
    }
}
