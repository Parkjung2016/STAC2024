using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//장비에서 피격시 발동해야할 이펙트가 있다면 여기서 발동시킴.
public class PlayerEffectByHit : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void HandleHitInvokeEffect()
    {
    }
}