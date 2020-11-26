// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/General/GalaxyHatWars_Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GalaxyHatWars_Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GalaxyHatWars_Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GalaxyHatWars_Inputs"",
    ""maps"": [
        {
            ""name"": ""DialogueSystem"",
            ""id"": ""092f65ed-156b-4b20-a010-dfb860ea99bf"",
            ""actions"": [
                {
                    ""name"": ""ToTheNext"",
                    ""type"": ""Button"",
                    ""id"": ""d327472d-a9c4-4f4d-a7d7-e9d611080e3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SkipDial"",
                    ""type"": ""Button"",
                    ""id"": ""f0298198-3203-454c-b1fb-027b0b9fc2a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a5239b70-0792-49da-bfa0-a4911bbbbcee"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""ToTheNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e98e0027-0812-4342-8c8e-df9e06a78137"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToTheNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d266e8fb-c122-4fe5-be72-f4d8c89917f6"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipDial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f56d3123-1a67-4630-9f28-f3541d038ac1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipDial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay"",
            ""id"": ""5065b151-3630-4a9f-9360-5c1cbc700009"",
            ""actions"": [
                {
                    ""name"": ""RunKeyboard"",
                    ""type"": ""Button"",
                    ""id"": ""f4073d33-12d5-4761-9605-1766aef357ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SensForward"",
                    ""type"": ""Value"",
                    ""id"": ""646222ed-5b18-44f6-9e01-02768b6d60df"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BatonFight"",
                    ""type"": ""Button"",
                    ""id"": ""f5ee1922-9c14-442b-8c42-7265bcac6c00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractionZone"",
                    ""type"": ""Button"",
                    ""id"": ""4d673e8e-3756-489f-a4f4-3a6ba801b730"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a39666f3-ae1c-445f-a834-432e1460d2cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""KeyA"",
                    ""type"": ""Button"",
                    ""id"": ""e8881a48-dab3-496b-9742-7b38ed0caef4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""KeyP"",
                    ""type"": ""Button"",
                    ""id"": ""92342f7d-9efc-4b2f-9d56-677f20735d9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""AllumeBaton"",
                    ""type"": ""Button"",
                    ""id"": ""2f027485-8026-4598-ab0f-09ca4c7fa7a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""InterractObject"",
                    ""type"": ""Button"",
                    ""id"": ""38302627-2d2e-4cf0-8927-2222c2ea87d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ReverseTourneObject"",
                    ""type"": ""Button"",
                    ""id"": ""e5fdfd72-4abb-4600-8b48-ea934d3c6380"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1793ec3e-9fef-415a-bf3a-035e360f7fd6"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""RunKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d58e1e4-8ce9-4da6-82d5-21ad9ce86a12"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.4,max=1),StickDeadzone(min=0.4,max=1)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SensForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""367822c5-9e4c-43e7-9a7b-4b488b8d2504"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SensForward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""73a4efb2-9aa6-4460-bf81-8217f94105ad"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""SensForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c22ba0ce-74d5-4f9d-b7c1-d7b58b64defe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""SensForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8ddf217f-c8e3-42c6-9d81-121ebd00cebe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""SensForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fec35652-9116-4dc4-b593-8821b65db8ee"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""SensForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""23cb1b3d-1c96-4097-a5ac-12e598021fa3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""BatonFight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92692d2b-10ef-491d-9408-be2a2803e608"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BatonFight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d1c678a-8cb0-40e4-9e64-3ef3344f7b25"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""InteractionZone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f99ff8ad-76ae-4d59-8135-4b3461071066"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractionZone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60610c0a-046a-4164-a83b-99fc028c7df5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7a02150-7061-4875-b8f2-c9ebfe2d3cf1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6bdc5a3-38dc-4980-bad1-898b67656e4c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad4c4fe4-c8b7-45b3-86ae-e6616261af0d"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""KeyP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""738a67c6-4b97-4179-a83c-69d1c1b44807"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AllumeBaton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7292b330-ac9d-41ab-a364-e632babb264b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""InterractObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74f8e395-91fb-40a7-a24f-32669172b63a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReverseTourneObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""786590fb-b1c4-46a0-97ff-f9f9d34933af"",
            ""actions"": [
                {
                    ""name"": ""Retour"",
                    ""type"": ""Button"",
                    ""id"": ""716cd542-7f38-4b9f-ad94-ec81384acd56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpDownManual"",
                    ""type"": ""Value"",
                    ""id"": ""e3b2b528-f156-4d66-ab73-71608146bf24"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df71be88-6535-4659-8132-d85e3872fbb4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Retour"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyboardAxis"",
                    ""id"": ""50e73c7b-38db-4452-9763-bfdaae9bd4a4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDownManual"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""90633347-a8d8-4d54-a94e-d7f429067607"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UpDownManual"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f3679ce6-4e09-454f-9566-15930ea5cb07"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""UpDownManual"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // DialogueSystem
        m_DialogueSystem = asset.FindActionMap("DialogueSystem", throwIfNotFound: true);
        m_DialogueSystem_ToTheNext = m_DialogueSystem.FindAction("ToTheNext", throwIfNotFound: true);
        m_DialogueSystem_SkipDial = m_DialogueSystem.FindAction("SkipDial", throwIfNotFound: true);
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_RunKeyboard = m_Gameplay.FindAction("RunKeyboard", throwIfNotFound: true);
        m_Gameplay_SensForward = m_Gameplay.FindAction("SensForward", throwIfNotFound: true);
        m_Gameplay_BatonFight = m_Gameplay.FindAction("BatonFight", throwIfNotFound: true);
        m_Gameplay_InteractionZone = m_Gameplay.FindAction("InteractionZone", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_KeyA = m_Gameplay.FindAction("KeyA", throwIfNotFound: true);
        m_Gameplay_KeyP = m_Gameplay.FindAction("KeyP", throwIfNotFound: true);
        m_Gameplay_AllumeBaton = m_Gameplay.FindAction("AllumeBaton", throwIfNotFound: true);
        m_Gameplay_InterractObject = m_Gameplay.FindAction("InterractObject", throwIfNotFound: true);
        m_Gameplay_ReverseTourneObject = m_Gameplay.FindAction("ReverseTourneObject", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Retour = m_Menu.FindAction("Retour", throwIfNotFound: true);
        m_Menu_UpDownManual = m_Menu.FindAction("UpDownManual", throwIfNotFound: true);
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

    // DialogueSystem
    private readonly InputActionMap m_DialogueSystem;
    private IDialogueSystemActions m_DialogueSystemActionsCallbackInterface;
    private readonly InputAction m_DialogueSystem_ToTheNext;
    private readonly InputAction m_DialogueSystem_SkipDial;
    public struct DialogueSystemActions
    {
        private @GalaxyHatWars_Inputs m_Wrapper;
        public DialogueSystemActions(@GalaxyHatWars_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToTheNext => m_Wrapper.m_DialogueSystem_ToTheNext;
        public InputAction @SkipDial => m_Wrapper.m_DialogueSystem_SkipDial;
        public InputActionMap Get() { return m_Wrapper.m_DialogueSystem; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueSystemActions set) { return set.Get(); }
        public void SetCallbacks(IDialogueSystemActions instance)
        {
            if (m_Wrapper.m_DialogueSystemActionsCallbackInterface != null)
            {
                @ToTheNext.started -= m_Wrapper.m_DialogueSystemActionsCallbackInterface.OnToTheNext;
                @ToTheNext.performed -= m_Wrapper.m_DialogueSystemActionsCallbackInterface.OnToTheNext;
                @ToTheNext.canceled -= m_Wrapper.m_DialogueSystemActionsCallbackInterface.OnToTheNext;
                @SkipDial.started -= m_Wrapper.m_DialogueSystemActionsCallbackInterface.OnSkipDial;
                @SkipDial.performed -= m_Wrapper.m_DialogueSystemActionsCallbackInterface.OnSkipDial;
                @SkipDial.canceled -= m_Wrapper.m_DialogueSystemActionsCallbackInterface.OnSkipDial;
            }
            m_Wrapper.m_DialogueSystemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToTheNext.started += instance.OnToTheNext;
                @ToTheNext.performed += instance.OnToTheNext;
                @ToTheNext.canceled += instance.OnToTheNext;
                @SkipDial.started += instance.OnSkipDial;
                @SkipDial.performed += instance.OnSkipDial;
                @SkipDial.canceled += instance.OnSkipDial;
            }
        }
    }
    public DialogueSystemActions @DialogueSystem => new DialogueSystemActions(this);

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_RunKeyboard;
    private readonly InputAction m_Gameplay_SensForward;
    private readonly InputAction m_Gameplay_BatonFight;
    private readonly InputAction m_Gameplay_InteractionZone;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_KeyA;
    private readonly InputAction m_Gameplay_KeyP;
    private readonly InputAction m_Gameplay_AllumeBaton;
    private readonly InputAction m_Gameplay_InterractObject;
    private readonly InputAction m_Gameplay_ReverseTourneObject;
    public struct GameplayActions
    {
        private @GalaxyHatWars_Inputs m_Wrapper;
        public GameplayActions(@GalaxyHatWars_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @RunKeyboard => m_Wrapper.m_Gameplay_RunKeyboard;
        public InputAction @SensForward => m_Wrapper.m_Gameplay_SensForward;
        public InputAction @BatonFight => m_Wrapper.m_Gameplay_BatonFight;
        public InputAction @InteractionZone => m_Wrapper.m_Gameplay_InteractionZone;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @KeyA => m_Wrapper.m_Gameplay_KeyA;
        public InputAction @KeyP => m_Wrapper.m_Gameplay_KeyP;
        public InputAction @AllumeBaton => m_Wrapper.m_Gameplay_AllumeBaton;
        public InputAction @InterractObject => m_Wrapper.m_Gameplay_InterractObject;
        public InputAction @ReverseTourneObject => m_Wrapper.m_Gameplay_ReverseTourneObject;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @RunKeyboard.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunKeyboard;
                @RunKeyboard.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunKeyboard;
                @RunKeyboard.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunKeyboard;
                @SensForward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSensForward;
                @SensForward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSensForward;
                @SensForward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSensForward;
                @BatonFight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBatonFight;
                @BatonFight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBatonFight;
                @BatonFight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBatonFight;
                @InteractionZone.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractionZone;
                @InteractionZone.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractionZone;
                @InteractionZone.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractionZone;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @KeyA.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKeyA;
                @KeyA.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKeyA;
                @KeyA.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKeyA;
                @KeyP.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKeyP;
                @KeyP.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKeyP;
                @KeyP.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKeyP;
                @AllumeBaton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAllumeBaton;
                @AllumeBaton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAllumeBaton;
                @AllumeBaton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAllumeBaton;
                @InterractObject.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInterractObject;
                @InterractObject.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInterractObject;
                @InterractObject.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInterractObject;
                @ReverseTourneObject.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReverseTourneObject;
                @ReverseTourneObject.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReverseTourneObject;
                @ReverseTourneObject.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReverseTourneObject;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RunKeyboard.started += instance.OnRunKeyboard;
                @RunKeyboard.performed += instance.OnRunKeyboard;
                @RunKeyboard.canceled += instance.OnRunKeyboard;
                @SensForward.started += instance.OnSensForward;
                @SensForward.performed += instance.OnSensForward;
                @SensForward.canceled += instance.OnSensForward;
                @BatonFight.started += instance.OnBatonFight;
                @BatonFight.performed += instance.OnBatonFight;
                @BatonFight.canceled += instance.OnBatonFight;
                @InteractionZone.started += instance.OnInteractionZone;
                @InteractionZone.performed += instance.OnInteractionZone;
                @InteractionZone.canceled += instance.OnInteractionZone;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @KeyA.started += instance.OnKeyA;
                @KeyA.performed += instance.OnKeyA;
                @KeyA.canceled += instance.OnKeyA;
                @KeyP.started += instance.OnKeyP;
                @KeyP.performed += instance.OnKeyP;
                @KeyP.canceled += instance.OnKeyP;
                @AllumeBaton.started += instance.OnAllumeBaton;
                @AllumeBaton.performed += instance.OnAllumeBaton;
                @AllumeBaton.canceled += instance.OnAllumeBaton;
                @InterractObject.started += instance.OnInterractObject;
                @InterractObject.performed += instance.OnInterractObject;
                @InterractObject.canceled += instance.OnInterractObject;
                @ReverseTourneObject.started += instance.OnReverseTourneObject;
                @ReverseTourneObject.performed += instance.OnReverseTourneObject;
                @ReverseTourneObject.canceled += instance.OnReverseTourneObject;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Retour;
    private readonly InputAction m_Menu_UpDownManual;
    public struct MenuActions
    {
        private @GalaxyHatWars_Inputs m_Wrapper;
        public MenuActions(@GalaxyHatWars_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Retour => m_Wrapper.m_Menu_Retour;
        public InputAction @UpDownManual => m_Wrapper.m_Menu_UpDownManual;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Retour.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRetour;
                @Retour.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRetour;
                @Retour.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRetour;
                @UpDownManual.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnUpDownManual;
                @UpDownManual.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnUpDownManual;
                @UpDownManual.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnUpDownManual;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Retour.started += instance.OnRetour;
                @Retour.performed += instance.OnRetour;
                @Retour.canceled += instance.OnRetour;
                @UpDownManual.started += instance.OnUpDownManual;
                @UpDownManual.performed += instance.OnUpDownManual;
                @UpDownManual.canceled += instance.OnUpDownManual;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IDialogueSystemActions
    {
        void OnToTheNext(InputAction.CallbackContext context);
        void OnSkipDial(InputAction.CallbackContext context);
    }
    public interface IGameplayActions
    {
        void OnRunKeyboard(InputAction.CallbackContext context);
        void OnSensForward(InputAction.CallbackContext context);
        void OnBatonFight(InputAction.CallbackContext context);
        void OnInteractionZone(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnKeyA(InputAction.CallbackContext context);
        void OnKeyP(InputAction.CallbackContext context);
        void OnAllumeBaton(InputAction.CallbackContext context);
        void OnInterractObject(InputAction.CallbackContext context);
        void OnReverseTourneObject(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnRetour(InputAction.CallbackContext context);
        void OnUpDownManual(InputAction.CallbackContext context);
    }
}
