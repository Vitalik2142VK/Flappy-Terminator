using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _menu;
    [SerializeField] private Button _actionButton;

    public event Action GameStrat;

    //private void OnEnable()
    //{
    //    _actionButton.onClick.AddListener(OnButtonClick);
    //}

    //private void OnDisable()
    //{
    //    _actionButton.onClick.RemoveListener(OnButtonClick);

    //}

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
