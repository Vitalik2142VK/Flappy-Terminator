using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _menu;
    [SerializeField] private Button _actionButton;

    public event Action GameStrat;

    public void Open()
    {
        _menu.alpha = 1.0f;
        _actionButton.interactable = true;
    }

    public void Close()
    {
        _menu.alpha = 0.0f;
        _actionButton.interactable = false;
    }

    public void OnButtonClick()
    {
        GameStrat?.Invoke();
    }
}
