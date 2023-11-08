using System;
using OpenCover.Framework.Model;
using TMPro;
using UnityEngine;

public class InputEditor : MonoBehaviour
{
    [SerializeField] private BaseCommand command;
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private TextMeshProUGUI keyBindingText;
    private bool _isChangingBinding;

    public bool IsChangingBinding
    {
        get => _isChangingBinding;
        set
        {
            if (value) ChangeCommandText("assign " + command + " ___");
            else ChangeCommandText(command + " = " + keyCode);
            _isChangingBinding = value;
        }
    }

    private void Update()
    {
        if (IsChangingBinding) ChangeKeyBinding();
    }

    private void ChangeKeyBinding()
    {
        if (!Input.anyKeyDown) return;
        KeyCode pressedKeyCode = GetCurrentKeyDown();

        if (pressedKeyCode == KeyCode.Escape)
        {
            return;
        }

        InputHandler inputHandler = command.gameObject.GetComponent<InputHandler>();
        inputHandler.ChangeKeyBinding(command, pressedKeyCode);
        keyCode = pressedKeyCode;
        ChangeCommandText(command + " = " + keyCode);
        IsChangingBinding = false;
    }

    private KeyCode GetCurrentKeyDown()
    {
        KeyCode pressedKeyCode = KeyCode.None;
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(keyCode))
            {
                pressedKeyCode = keyCode;
            }
        }

        return pressedKeyCode;
    }

    private void Start()
    {
        ChangeCommandText(command + " = " + keyCode);
    }

    private void ChangeCommandText(string text)
    {
        keyBindingText.text = text;
    }
}