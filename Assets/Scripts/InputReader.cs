using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Input _input;
    public event Action MouseClicked;

    private KeyCode _activateButton = KeyCode.Mouse0;

    void Update()
    {
        if (Input.GetKeyDown(_activateButton))
        {
            MouseClicked?.Invoke();
        }
    }
}
