using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuitInMenuButton : MonoBehaviour
{
    private Button _button;

    public UnityAction ButtonPressed;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        ButtonPressed?.Invoke();
        Menu.Load();
    }
}
