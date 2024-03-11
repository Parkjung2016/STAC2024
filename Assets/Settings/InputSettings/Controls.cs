//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/InputSettings/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""1e1d539f-7977-4060-a697-c46f03c0af43"",
            ""actions"": [
                {
                    ""name"": ""XMovement"",
                    ""type"": ""Value"",
                    ""id"": ""bff93c89-7e52-4063-a5a1-8cdbc54e037f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c93dfb89-6146-4c3c-a838-9868255b5a47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""e8aaefae-4420-494f-981f-11cf8c10e87b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""YMovement"",
                    ""type"": ""Value"",
                    ""id"": ""295f87df-b974-451a-aadb-486eb665ad49"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""51d86485-ecf5-410c-bdeb-e78206809498"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CounterAttack"",
                    ""type"": ""Button"",
                    ""id"": ""282457f3-634b-4193-abfe-5f0f1a7b02f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowAim"",
                    ""type"": ""Button"",
                    ""id"": ""e9142377-8691-453e-b14f-fc33717e5c17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseAim"",
                    ""type"": ""Value"",
                    ""id"": ""28f874af-c32b-4508-9f80-3b3257682a30"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""UltiSkill"",
                    ""type"": ""Button"",
                    ""id"": ""daacc0f2-617d-4e9c-a0be-57fd8eb32769"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CrystalSkill"",
                    ""type"": ""Button"",
                    ""id"": ""56e6e507-886e-4111-8811-e3da8484c9a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HealFlask"",
                    ""type"": ""Button"",
                    ""id"": ""91565cc9-7e9e-41ef-9e31-8c48718a35c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""1ef6d854-fc83-4193-80a9-031ecb243864"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""576290f1-8f70-437f-a8be-6da1f23898da"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff32b9bc-dcd2-4ef1-abac-18d23720ef6a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""c839e5ab-45a3-41b4-86cf-d523ac5d9087"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1c067be1-2e1a-401b-829a-c3cff1a39bc2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e75716c5-003e-4c9d-a054-a4128c303863"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""df186cf1-68b2-48ad-b471-01c6aa1cf844"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""652379f0-8de3-4b0c-9d2a-12d2d5bdaf23"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dc9999d2-18e4-4f4f-bb40-e56811812860"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9ca1f3bf-9726-48e6-bcd4-68b5276a8eac"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4553a9d2-0a20-4f64-985b-60626e164640"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CounterAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe32ca20-1dcc-4a3d-bf1e-c5c043f1b9f8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a157b3d5-9535-419a-9f5a-b21517c990d7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MouseAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bebae9dc-e38d-4234-af17-37ee41f2398f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""UltiSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9977f81-72a3-461a-98a6-e4e65e137426"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CrystalSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""321928db-c540-4207-8c6c-279de1c09bd8"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""HealFlask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a09b4fa-8408-40be-a015-000fe03de676"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""0ee8a1ed-f6c0-481e-80e8-94b316a491fe"",
            ""actions"": [
                {
                    ""name"": ""OpenUI"",
                    ""type"": ""Button"",
                    ""id"": ""73a6870b-e32f-4181-9084-93bbe7037f23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""811d6a58-746e-4def-aa35-ba905f74384f"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_XMovement = m_Player.FindAction("XMovement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_YMovement = m_Player.FindAction("YMovement", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_CounterAttack = m_Player.FindAction("CounterAttack", throwIfNotFound: true);
        m_Player_ThrowAim = m_Player.FindAction("ThrowAim", throwIfNotFound: true);
        m_Player_MouseAim = m_Player.FindAction("MouseAim", throwIfNotFound: true);
        m_Player_UltiSkill = m_Player.FindAction("UltiSkill", throwIfNotFound: true);
        m_Player_CrystalSkill = m_Player.FindAction("CrystalSkill", throwIfNotFound: true);
        m_Player_HealFlask = m_Player.FindAction("HealFlask", throwIfNotFound: true);
        m_Player_Interaction = m_Player.FindAction("Interaction", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_OpenUI = m_UI.FindAction("OpenUI", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_XMovement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_YMovement;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_CounterAttack;
    private readonly InputAction m_Player_ThrowAim;
    private readonly InputAction m_Player_MouseAim;
    private readonly InputAction m_Player_UltiSkill;
    private readonly InputAction m_Player_CrystalSkill;
    private readonly InputAction m_Player_HealFlask;
    private readonly InputAction m_Player_Interaction;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @XMovement => m_Wrapper.m_Player_XMovement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @YMovement => m_Wrapper.m_Player_YMovement;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @CounterAttack => m_Wrapper.m_Player_CounterAttack;
        public InputAction @ThrowAim => m_Wrapper.m_Player_ThrowAim;
        public InputAction @MouseAim => m_Wrapper.m_Player_MouseAim;
        public InputAction @UltiSkill => m_Wrapper.m_Player_UltiSkill;
        public InputAction @CrystalSkill => m_Wrapper.m_Player_CrystalSkill;
        public InputAction @HealFlask => m_Wrapper.m_Player_HealFlask;
        public InputAction @Interaction => m_Wrapper.m_Player_Interaction;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @XMovement.started += instance.OnXMovement;
            @XMovement.performed += instance.OnXMovement;
            @XMovement.canceled += instance.OnXMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @YMovement.started += instance.OnYMovement;
            @YMovement.performed += instance.OnYMovement;
            @YMovement.canceled += instance.OnYMovement;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @CounterAttack.started += instance.OnCounterAttack;
            @CounterAttack.performed += instance.OnCounterAttack;
            @CounterAttack.canceled += instance.OnCounterAttack;
            @ThrowAim.started += instance.OnThrowAim;
            @ThrowAim.performed += instance.OnThrowAim;
            @ThrowAim.canceled += instance.OnThrowAim;
            @MouseAim.started += instance.OnMouseAim;
            @MouseAim.performed += instance.OnMouseAim;
            @MouseAim.canceled += instance.OnMouseAim;
            @UltiSkill.started += instance.OnUltiSkill;
            @UltiSkill.performed += instance.OnUltiSkill;
            @UltiSkill.canceled += instance.OnUltiSkill;
            @CrystalSkill.started += instance.OnCrystalSkill;
            @CrystalSkill.performed += instance.OnCrystalSkill;
            @CrystalSkill.canceled += instance.OnCrystalSkill;
            @HealFlask.started += instance.OnHealFlask;
            @HealFlask.performed += instance.OnHealFlask;
            @HealFlask.canceled += instance.OnHealFlask;
            @Interaction.started += instance.OnInteraction;
            @Interaction.performed += instance.OnInteraction;
            @Interaction.canceled += instance.OnInteraction;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @XMovement.started -= instance.OnXMovement;
            @XMovement.performed -= instance.OnXMovement;
            @XMovement.canceled -= instance.OnXMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @YMovement.started -= instance.OnYMovement;
            @YMovement.performed -= instance.OnYMovement;
            @YMovement.canceled -= instance.OnYMovement;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @CounterAttack.started -= instance.OnCounterAttack;
            @CounterAttack.performed -= instance.OnCounterAttack;
            @CounterAttack.canceled -= instance.OnCounterAttack;
            @ThrowAim.started -= instance.OnThrowAim;
            @ThrowAim.performed -= instance.OnThrowAim;
            @ThrowAim.canceled -= instance.OnThrowAim;
            @MouseAim.started -= instance.OnMouseAim;
            @MouseAim.performed -= instance.OnMouseAim;
            @MouseAim.canceled -= instance.OnMouseAim;
            @UltiSkill.started -= instance.OnUltiSkill;
            @UltiSkill.performed -= instance.OnUltiSkill;
            @UltiSkill.canceled -= instance.OnUltiSkill;
            @CrystalSkill.started -= instance.OnCrystalSkill;
            @CrystalSkill.performed -= instance.OnCrystalSkill;
            @CrystalSkill.canceled -= instance.OnCrystalSkill;
            @HealFlask.started -= instance.OnHealFlask;
            @HealFlask.performed -= instance.OnHealFlask;
            @HealFlask.canceled -= instance.OnHealFlask;
            @Interaction.started -= instance.OnInteraction;
            @Interaction.performed -= instance.OnInteraction;
            @Interaction.canceled -= instance.OnInteraction;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_OpenUI;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenUI => m_Wrapper.m_UI_OpenUI;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @OpenUI.started += instance.OnOpenUI;
            @OpenUI.performed += instance.OnOpenUI;
            @OpenUI.canceled += instance.OnOpenUI;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @OpenUI.started -= instance.OnOpenUI;
            @OpenUI.performed -= instance.OnOpenUI;
            @OpenUI.canceled -= instance.OnOpenUI;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnXMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnYMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnCounterAttack(InputAction.CallbackContext context);
        void OnThrowAim(InputAction.CallbackContext context);
        void OnMouseAim(InputAction.CallbackContext context);
        void OnUltiSkill(InputAction.CallbackContext context);
        void OnCrystalSkill(InputAction.CallbackContext context);
        void OnHealFlask(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnOpenUI(InputAction.CallbackContext context);
    }
}