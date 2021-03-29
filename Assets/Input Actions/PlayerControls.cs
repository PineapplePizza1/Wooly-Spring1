// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement MK"",
            ""id"": ""907cee22-7e67-4c34-9332-e86fa80bab70"",
            ""actions"": [
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""83b6eed5-f9f3-4ae1-a806-f240838f2933"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseZoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""24e283fe-404d-42d7-8a41-56083afce68c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ccc562a3-170a-4a27-9722-a8f531e71108"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c213700d-31b5-4f97-ba75-7768b0f490e5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""ef329950-cc12-458a-9b0e-43751afae299"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e96e35b0-f57b-4220-adf7-594ce75d79e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""ae791797-9e51-453d-94ff-9d269b5a526e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""2fda0f0b-725a-4d22-9da8-dc8ab168132a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Utility"",
                    ""type"": ""Button"",
                    ""id"": ""7a2215c8-ad0a-4a94-8b8d-43f74e4d62e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""02230462-f842-4ec9-be64-e8558abfc5bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""07f95b5c-0da5-4fcb-96cb-7200be34f67a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c27dd0c4-4e79-424a-bf45-f9972317c14b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20500ef4-12b6-42d0-8a43-3bd759a68b75"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c39ce045-6831-48d2-8ca8-ac1f43bf2de1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""23e81327-2a99-460f-93f7-b99c8d0c6c1a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""27c8e611-bb3d-4578-8d0c-ecf26c042983"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""faa3ebce-586a-44c0-b8b0-12548f41f899"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a3badd89-128d-4d3b-89c3-f1571ed548cb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7c0e88b5-a703-44f6-a86e-65f1eec25227"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c85f15d5-b6d6-4131-96d6-20c9aa145f26"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62ff2554-214c-4e10-bc10-53c71ce0d875"",
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
                    ""id"": ""c49951ec-0580-468b-939e-f377e7f2a20c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2624e3a-231b-43c8-89ac-0b69cbe00724"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b554408-6e2b-4e53-b59d-1c6f01f39645"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Utility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""713c9c80-03be-432b-b38e-71b84a5ff839"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e97d57a7-5b62-4eca-a7ea-f7b649f58680"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""bbcab9f8-3cac-4d58-9e3e-3dbfe44ca621"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""0fecf8e5-66c4-4d0a-a1a0-606913065d64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleUI"",
                    ""type"": ""Button"",
                    ""id"": ""3bf40829-a3ef-44e7-b842-6c1cabf83342"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DieBind"",
                    ""type"": ""Button"",
                    ""id"": ""14c86142-bb36-4bb8-9000-3dceca2cc92c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DBGdmg"",
                    ""type"": ""Button"",
                    ""id"": ""7d16247c-4c1b-477b-af7d-4f30caf396c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""12da3bfe-0d9f-4028-81ae-42eb8a8fbed8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fd75ba6b-55e5-4d1d-93ec-b96ee158fe8a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""343c6860-d7d7-43bd-9ef6-6331eed33d92"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55ec9675-bc4d-4ba5-8509-71cdf0a9f3ac"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DieBind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7609f46-4041-4d0a-9bf7-347a9ac94c3a"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DBGdmg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e4746e4-a441-48a0-8746-d94f28f62472"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement MK
        m_MovementMK = asset.FindActionMap("Movement MK", throwIfNotFound: true);
        m_MovementMK_MouseLook = m_MovementMK.FindAction("MouseLook", throwIfNotFound: true);
        m_MovementMK_MouseZoom = m_MovementMK.FindAction("MouseZoom", throwIfNotFound: true);
        m_MovementMK_Horizontal = m_MovementMK.FindAction("Horizontal", throwIfNotFound: true);
        m_MovementMK_Vertical = m_MovementMK.FindAction("Vertical", throwIfNotFound: true);
        m_MovementMK_Sprint = m_MovementMK.FindAction("Sprint", throwIfNotFound: true);
        m_MovementMK_Jump = m_MovementMK.FindAction("Jump", throwIfNotFound: true);
        m_MovementMK_Primary = m_MovementMK.FindAction("Primary", throwIfNotFound: true);
        m_MovementMK_Secondary = m_MovementMK.FindAction("Secondary", throwIfNotFound: true);
        m_MovementMK_Utility = m_MovementMK.FindAction("Utility", throwIfNotFound: true);
        m_MovementMK_Ability = m_MovementMK.FindAction("Ability", throwIfNotFound: true);
        m_MovementMK_Interact = m_MovementMK.FindAction("Interact", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Quit = m_Debug.FindAction("Quit", throwIfNotFound: true);
        m_Debug_ToggleUI = m_Debug.FindAction("ToggleUI", throwIfNotFound: true);
        m_Debug_DieBind = m_Debug.FindAction("DieBind", throwIfNotFound: true);
        m_Debug_DBGdmg = m_Debug.FindAction("DBGdmg", throwIfNotFound: true);
        m_Debug_Reset = m_Debug.FindAction("Reset", throwIfNotFound: true);
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

    // Movement MK
    private readonly InputActionMap m_MovementMK;
    private IMovementMKActions m_MovementMKActionsCallbackInterface;
    private readonly InputAction m_MovementMK_MouseLook;
    private readonly InputAction m_MovementMK_MouseZoom;
    private readonly InputAction m_MovementMK_Horizontal;
    private readonly InputAction m_MovementMK_Vertical;
    private readonly InputAction m_MovementMK_Sprint;
    private readonly InputAction m_MovementMK_Jump;
    private readonly InputAction m_MovementMK_Primary;
    private readonly InputAction m_MovementMK_Secondary;
    private readonly InputAction m_MovementMK_Utility;
    private readonly InputAction m_MovementMK_Ability;
    private readonly InputAction m_MovementMK_Interact;
    public struct MovementMKActions
    {
        private @PlayerControls m_Wrapper;
        public MovementMKActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLook => m_Wrapper.m_MovementMK_MouseLook;
        public InputAction @MouseZoom => m_Wrapper.m_MovementMK_MouseZoom;
        public InputAction @Horizontal => m_Wrapper.m_MovementMK_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_MovementMK_Vertical;
        public InputAction @Sprint => m_Wrapper.m_MovementMK_Sprint;
        public InputAction @Jump => m_Wrapper.m_MovementMK_Jump;
        public InputAction @Primary => m_Wrapper.m_MovementMK_Primary;
        public InputAction @Secondary => m_Wrapper.m_MovementMK_Secondary;
        public InputAction @Utility => m_Wrapper.m_MovementMK_Utility;
        public InputAction @Ability => m_Wrapper.m_MovementMK_Ability;
        public InputAction @Interact => m_Wrapper.m_MovementMK_Interact;
        public InputActionMap Get() { return m_Wrapper.m_MovementMK; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementMKActions set) { return set.Get(); }
        public void SetCallbacks(IMovementMKActions instance)
        {
            if (m_Wrapper.m_MovementMKActionsCallbackInterface != null)
            {
                @MouseLook.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnMouseLook;
                @MouseZoom.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnMouseZoom;
                @MouseZoom.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnMouseZoom;
                @MouseZoom.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnMouseZoom;
                @Horizontal.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnVertical;
                @Sprint.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnJump;
                @Primary.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnPrimary;
                @Secondary.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnSecondary;
                @Utility.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnUtility;
                @Utility.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnUtility;
                @Utility.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnUtility;
                @Ability.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnAbility;
                @Interact.started -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MovementMKActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_MovementMKActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @MouseZoom.started += instance.OnMouseZoom;
                @MouseZoom.performed += instance.OnMouseZoom;
                @MouseZoom.canceled += instance.OnMouseZoom;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
                @Utility.started += instance.OnUtility;
                @Utility.performed += instance.OnUtility;
                @Utility.canceled += instance.OnUtility;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public MovementMKActions @MovementMK => new MovementMKActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_Quit;
    private readonly InputAction m_Debug_ToggleUI;
    private readonly InputAction m_Debug_DieBind;
    private readonly InputAction m_Debug_DBGdmg;
    private readonly InputAction m_Debug_Reset;
    public struct DebugActions
    {
        private @PlayerControls m_Wrapper;
        public DebugActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_Debug_Quit;
        public InputAction @ToggleUI => m_Wrapper.m_Debug_ToggleUI;
        public InputAction @DieBind => m_Wrapper.m_Debug_DieBind;
        public InputAction @DBGdmg => m_Wrapper.m_Debug_DBGdmg;
        public InputAction @Reset => m_Wrapper.m_Debug_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnQuit;
                @ToggleUI.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleUI;
                @ToggleUI.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleUI;
                @ToggleUI.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleUI;
                @DieBind.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnDieBind;
                @DieBind.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnDieBind;
                @DieBind.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnDieBind;
                @DBGdmg.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnDBGdmg;
                @DBGdmg.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnDBGdmg;
                @DBGdmg.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnDBGdmg;
                @Reset.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @ToggleUI.started += instance.OnToggleUI;
                @ToggleUI.performed += instance.OnToggleUI;
                @ToggleUI.canceled += instance.OnToggleUI;
                @DieBind.started += instance.OnDieBind;
                @DieBind.performed += instance.OnDieBind;
                @DieBind.canceled += instance.OnDieBind;
                @DBGdmg.started += instance.OnDBGdmg;
                @DBGdmg.performed += instance.OnDBGdmg;
                @DBGdmg.canceled += instance.OnDBGdmg;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMovementMKActions
    {
        void OnMouseLook(InputAction.CallbackContext context);
        void OnMouseZoom(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnUtility(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnQuit(InputAction.CallbackContext context);
        void OnToggleUI(InputAction.CallbackContext context);
        void OnDieBind(InputAction.CallbackContext context);
        void OnDBGdmg(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
}
