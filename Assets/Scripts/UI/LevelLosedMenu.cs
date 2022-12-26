using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLosedMenu : MonoBehaviour
{
    public UnityAction LosedMenuOpened;
    public UnityAction LosedMenuClosed;

    private void OnEnable()
    {
        LosedMenuOpened?.Invoke();
    }

    private void OnDisable()
    {
        LosedMenuClosed?.Invoke();
    }
}
