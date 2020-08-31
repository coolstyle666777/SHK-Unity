using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverPanel : MonoBehaviour
{
    private CanvasGroup _panel;

    private void Awake()
    {
        _panel = GetComponent<CanvasGroup>();
    }

    public void ShowPanel()
    {
        _panel.alpha = 1;
    }
}
