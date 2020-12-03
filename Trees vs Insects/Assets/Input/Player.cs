// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""1891be02-8b04-419f-b11e-1e21bcd21210"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""05fcfcf0-72a3-41ee-b2f2-5e92c1cb9adb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Deselect"",
                    ""type"": ""Button"",
                    ""id"": ""f0386fb4-94a4-4deb-9c21-41669d39e3ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""59d29164-2fbf-4535-a800-f149f1184cbf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""fc5fd069-bb16-433e-8e85-88d138dbeebc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9d44170-901d-41fe-a412-c78b530427b9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""044e0f52-558e-45e5-a4ac-8712cc0764ae"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deselect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54d3790b-26b6-4750-ad22-67b4ac820a03"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c62ff89-75ea-4844-a2ec-ddbc299819ac"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Select = m_Keyboard.FindAction("Select", throwIfNotFound: true);
        m_Keyboard_Deselect = m_Keyboard.FindAction("Deselect", throwIfNotFound: true);
        m_Keyboard_Move = m_Keyboard.FindAction("Move", throwIfNotFound: true);
        m_Keyboard_Esc = m_Keyboard.FindAction("Esc", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Select;
    private readonly InputAction m_Keyboard_Deselect;
    private readonly InputAction m_Keyboard_Move;
    private readonly InputAction m_Keyboard_Esc;
    public struct KeyboardActions
    {
        private @Player m_Wrapper;
        public KeyboardActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Keyboard_Select;
        public InputAction @Deselect => m_Wrapper.m_Keyboard_Deselect;
        public InputAction @Move => m_Wrapper.m_Keyboard_Move;
        public InputAction @Esc => m_Wrapper.m_Keyboard_Esc;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSelect;
                @Deselect.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDeselect;
                @Deselect.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDeselect;
                @Deselect.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDeselect;
                @Move.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Esc.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEsc;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Deselect.started += instance.OnDeselect;
                @Deselect.performed += instance.OnDeselect;
                @Deselect.canceled += instance.OnDeselect;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnDeselect(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnEsc(InputAction.CallbackContext context);
    }
}
