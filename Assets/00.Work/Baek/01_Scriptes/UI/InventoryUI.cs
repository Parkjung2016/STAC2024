using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UAPT.Utile;
public class InventoryUI : MonoBehaviour
{
    private UIDocument _doc;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        var root = _doc.rootVisualElement;
        var btnRoot = root.Q<VisualElement>("inventory_bottom_contain-box");

        Button profileBtn = btnRoot.Q<Button>("profil_tabbar-button");
        Button inventoryBtn = btnRoot.Q<Button>("bag_tabbar-button");

        VisualElement profilePage = root.Q<VisualElement>("profil_page_contain-box");
        VisualElement inventoryPage = root.Q<VisualElement>("inventory_page_contain-box");

        ToolKitUtile.SetClikeEvent(profileBtn, () => { profilePage.RemoveFromClassList("on"); inventoryPage.AddToClassList("on"); Debug.Log("dd"); });
        ToolKitUtile.SetClikeEvent(inventoryBtn, () => { inventoryPage.RemoveFromClassList("on"); profilePage.AddToClassList("on"); });
    }
}





