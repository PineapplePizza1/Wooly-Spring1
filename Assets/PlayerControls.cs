// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

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
            }
        }
    }
    public MovementMKActions @MovementMK => new MovementMKActions(this);
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
    }
}
