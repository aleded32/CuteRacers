// GENERATED AUTOMATICALLY FROM 'Assets/inputSystem/playerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @playerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @playerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerInput"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""218bad7e-23c0-472c-b788-4e4437624c8b"",
            ""actions"": [
                {
                    ""name"": ""throttle"",
                    ""type"": ""Value"",
                    ""id"": ""b3447907-c043-43c5-b901-732d906c0452"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""brake"",
                    ""type"": ""Value"",
                    ""id"": ""07b38896-fb5b-42d5-af91-fed2efc9f8f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""turn"",
                    ""type"": ""Value"",
                    ""id"": ""534bdf5c-2691-4f6f-8086-f277d9c0da17"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b5e99f92-ef85-4ff3-bdf8-ea4a01bef1f3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller1;controller2"",
                    ""action"": ""throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51ecfe3a-fe38-49db-bcbc-a55af8327de2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller2;controller1"",
                    ""action"": ""brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4930fea5-607d-4b2f-8d58-eaa848be3569"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller1;controller2"",
                    ""action"": ""turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""controller1"",
            ""bindingGroup"": ""controller1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""controller2"",
            ""bindingGroup"": ""controller2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_throttle = m_player.FindAction("throttle", throwIfNotFound: true);
        m_player_brake = m_player.FindAction("brake", throwIfNotFound: true);
        m_player_turn = m_player.FindAction("turn", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_player_throttle;
    private readonly InputAction m_player_brake;
    private readonly InputAction m_player_turn;
    public struct PlayerActions
    {
        private @playerInputActions m_Wrapper;
        public PlayerActions(@playerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @throttle => m_Wrapper.m_player_throttle;
        public InputAction @brake => m_Wrapper.m_player_brake;
        public InputAction @turn => m_Wrapper.m_player_turn;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @throttle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottle;
                @throttle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottle;
                @throttle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottle;
                @brake.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrake;
                @brake.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrake;
                @brake.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBrake;
                @turn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurn;
                @turn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurn;
                @turn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurn;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @throttle.started += instance.OnThrottle;
                @throttle.performed += instance.OnThrottle;
                @throttle.canceled += instance.OnThrottle;
                @brake.started += instance.OnBrake;
                @brake.performed += instance.OnBrake;
                @brake.canceled += instance.OnBrake;
                @turn.started += instance.OnTurn;
                @turn.performed += instance.OnTurn;
                @turn.canceled += instance.OnTurn;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    private int m_controller1SchemeIndex = -1;
    public InputControlScheme controller1Scheme
    {
        get
        {
            if (m_controller1SchemeIndex == -1) m_controller1SchemeIndex = asset.FindControlSchemeIndex("controller1");
            return asset.controlSchemes[m_controller1SchemeIndex];
        }
    }
    private int m_controller2SchemeIndex = -1;
    public InputControlScheme controller2Scheme
    {
        get
        {
            if (m_controller2SchemeIndex == -1) m_controller2SchemeIndex = asset.FindControlSchemeIndex("controller2");
            return asset.controlSchemes[m_controller2SchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
    }
}
