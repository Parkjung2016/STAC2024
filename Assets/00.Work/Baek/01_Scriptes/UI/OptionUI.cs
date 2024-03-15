using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class OptionUI : MonoBehaviour
{
    private UIDocument _doc;
    private VisualElement _root;
    private VisualElement _option;
    private bool _onOption;
    [SerializeField] private string _exitScenenName;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _root = _doc.rootVisualElement;
        _option = _root.Q<VisualElement>("screen_contain-box");
        ButtonInit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WindowSet();
        }
    }
    private void WindowSet()
    {
        if (_onOption == true)
        {
            _option.AddToClassList("on");
        }
        if (_onOption == false)
        {
            _option.RemoveFromClassList("on");
        }
        _onOption = !_onOption;
    }
    private void ButtonInit()
    {
        _root.Q<Button>("continue-button").RegisterCallback<ClickEvent>(evt => WindowSet());
        _root.Q<Button>("exit-button").RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(_exitScenenName));
    }


}
