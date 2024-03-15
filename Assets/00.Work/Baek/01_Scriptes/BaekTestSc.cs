using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaekTestSc : MonoBehaviour
{
    [SerializeField] private InventoryUI qwer;
    private bool a;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            a = !a;
        }
    }
}
