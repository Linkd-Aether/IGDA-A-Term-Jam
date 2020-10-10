// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Player.inputactions'

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
            ""name"": ""GameWindows"",
            ""id"": ""979f5b68-1db6-43e0-836f-847209c6bf56"",
            ""actions"": [
                {
                    ""name"": ""MoveL"",
                    ""type"": ""Value"",
                    ""id"": ""4404b7f3-493b-4d13-b4da-01d2d3057890"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveR"",
                    ""type"": ""Value"",
                    ""id"": ""a2b469b3-a035-48b3-82a3-433025e65668"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Shifting"",
                    ""type"": ""Button"",
                    ""id"": ""c5889c29-da6d-4f1b-88b1-4a3c263f3644"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ButtonL"",
                    ""type"": ""Button"",
                    ""id"": ""f86a1c91-5076-49ed-a8c8-5eb11d3f9960"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""8cb69a78-bc76-44fe-af3b-a0441ec1f32a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button1"",
                    ""type"": ""Button"",
                    ""id"": ""8b691b29-efa6-494b-b832-30bd1a30443c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button2"",
                    ""type"": ""Button"",
                    ""id"": ""490e6111-ddec-4c58-9654-e39e84778e38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button3"",
                    ""type"": ""Button"",
                    ""id"": ""6a4d73ec-314f-43cf-b21c-2db571f077f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f1a39d6f-e18a-418b-bcd7-e74107cc0fd5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""025fba00-dfb3-47ac-80a0-19d6d724f8e8"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveL"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""52fbdecc-bbc5-4bb3-bda8-1090e0033825"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1006e5b4-e4a2-43cb-8381-bb32c392d087"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""90d9d134-fca9-4df4-98c1-72b62f661c07"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dc11212a-6b28-4008-87dc-7424f154dbcd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9e0d52dc-b98d-4b1e-bc3a-dedb17df29d3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""b3b55b51-8738-4d1d-aa59-cfcf1e8b8e58"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press(pressPoint=2,behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2468201f-948e-4d18-a0d3-db27684b58ad"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8d86c59e-331c-46be-910a-f4bdbf1aaa57"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ad6f670f-035e-4690-b95f-89d7fe8446b5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1588210d-167c-4852-8f56-3816b238c27f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MoveR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""db7b081c-f971-41ac-a884-213cfb6f8063"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shifting"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""27b1a176-58f9-4bf7-bbfe-cc0f4c66e079"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Shifting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0946ebdc-406a-4019-949b-79c319aabd59"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Shifting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Bumpers"",
                    ""id"": ""5bacb916-ec8b-45f2-9f06-661080143731"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shifting"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bc157ad3-4560-437c-84ec-168fba02032e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shifting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c8583be2-54db-4ff1-b77c-f675ca77b3dd"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shifting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9ada9efd-27e0-400e-9e7f-b4a07f0a7c41"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72613fd2-ebcd-49c4-90ed-6e4650337872"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""ButtonL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a5b22b7-ca43-44f6-8b33-e97086155abb"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07a2886d-2a82-41eb-b020-98df36512f98"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5e5c201-123e-410f-a3c8-46478cafc05d"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fe2fead-f80b-4cb4-9045-9c0def87f07e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b06f9f42-e094-46f0-9148-5a26b9976a6e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""140456c7-681c-4fdd-8cc8-6a66ee0b3b81"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85fbebdf-621c-40e9-9d99-b09baebe4816"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a658bbbf-e2ed-4620-9835-2363396fb318"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47ddbf44-7040-4ac9-b1aa-ab6e8ca32532"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9331ea7-849c-4a2a-a9ce-ce5cf739edf1"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""165fc06c-5584-4a23-87e2-af6ef902aa91"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EndScreen"",
            ""id"": ""fd2eb26a-0134-46b9-8518-ff8c263dcb27"",
            ""actions"": [
                {
                    ""name"": ""ButtonPress"",
                    ""type"": ""Button"",
                    ""id"": ""f382d94e-787f-4342-bf8c-8e2eedba65b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""0b3f904a-38b0-428a-ba29-5a6e3bc26046"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shifting"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1635fa47-49ee-4784-a634-468d54ba359c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Shifting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""71d76703-0482-4d3a-b5cd-8e1e54b525f6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Shifting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""db530c40-dbc0-410d-a00e-ebc5807e1f2f"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c7186d2-c56d-4a47-a8a8-44d94e06d959"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ab7aead-6b21-4ee6-91f1-3c957c508c83"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b338bc1a-202c-4877-b434-2058b5fb6932"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e184cfd-12d1-4984-954b-5480e6605cdc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a88f343-fd78-4fb4-a6bc-30fab51965f5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faf5031c-066b-41de-880c-352a71fb5fc6"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0afaa689-43df-4f71-9819-037f3c7e2f46"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef8a018f-a568-4861-96d5-ae86b67da0bc"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a1a0b2f-a3a8-4cbb-85b7-64e999a347f2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebdf0856-23ce-4bab-b660-f9416c8f4d46"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""ButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""bindingGroup"": ""Keyboard/Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GameWindows
        m_GameWindows = asset.FindActionMap("GameWindows", throwIfNotFound: true);
        m_GameWindows_MoveL = m_GameWindows.FindAction("MoveL", throwIfNotFound: true);
        m_GameWindows_MoveR = m_GameWindows.FindAction("MoveR", throwIfNotFound: true);
        m_GameWindows_Shifting = m_GameWindows.FindAction("Shifting", throwIfNotFound: true);
        m_GameWindows_ButtonL = m_GameWindows.FindAction("ButtonL", throwIfNotFound: true);
        m_GameWindows_Selection = m_GameWindows.FindAction("Selection", throwIfNotFound: true);
        m_GameWindows_Button1 = m_GameWindows.FindAction("Button1", throwIfNotFound: true);
        m_GameWindows_Button2 = m_GameWindows.FindAction("Button2", throwIfNotFound: true);
        m_GameWindows_Button3 = m_GameWindows.FindAction("Button3", throwIfNotFound: true);
        // EndScreen
        m_EndScreen = asset.FindActionMap("EndScreen", throwIfNotFound: true);
        m_EndScreen_ButtonPress = m_EndScreen.FindAction("ButtonPress", throwIfNotFound: true);
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

    // GameWindows
    private readonly InputActionMap m_GameWindows;
    private IGameWindowsActions m_GameWindowsActionsCallbackInterface;
    private readonly InputAction m_GameWindows_MoveL;
    private readonly InputAction m_GameWindows_MoveR;
    private readonly InputAction m_GameWindows_Shifting;
    private readonly InputAction m_GameWindows_ButtonL;
    private readonly InputAction m_GameWindows_Selection;
    private readonly InputAction m_GameWindows_Button1;
    private readonly InputAction m_GameWindows_Button2;
    private readonly InputAction m_GameWindows_Button3;
    public struct GameWindowsActions
    {
        private @Player m_Wrapper;
        public GameWindowsActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveL => m_Wrapper.m_GameWindows_MoveL;
        public InputAction @MoveR => m_Wrapper.m_GameWindows_MoveR;
        public InputAction @Shifting => m_Wrapper.m_GameWindows_Shifting;
        public InputAction @ButtonL => m_Wrapper.m_GameWindows_ButtonL;
        public InputAction @Selection => m_Wrapper.m_GameWindows_Selection;
        public InputAction @Button1 => m_Wrapper.m_GameWindows_Button1;
        public InputAction @Button2 => m_Wrapper.m_GameWindows_Button2;
        public InputAction @Button3 => m_Wrapper.m_GameWindows_Button3;
        public InputActionMap Get() { return m_Wrapper.m_GameWindows; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameWindowsActions set) { return set.Get(); }
        public void SetCallbacks(IGameWindowsActions instance)
        {
            if (m_Wrapper.m_GameWindowsActionsCallbackInterface != null)
            {
                @MoveL.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnMoveL;
                @MoveL.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnMoveL;
                @MoveL.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnMoveL;
                @MoveR.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnMoveR;
                @MoveR.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnMoveR;
                @MoveR.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnMoveR;
                @Shifting.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnShifting;
                @Shifting.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnShifting;
                @Shifting.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnShifting;
                @ButtonL.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButtonL;
                @ButtonL.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButtonL;
                @ButtonL.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButtonL;
                @Selection.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnSelection;
                @Button1.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton1;
                @Button1.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton1;
                @Button1.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton1;
                @Button2.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton2;
                @Button2.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton2;
                @Button2.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton2;
                @Button3.started -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton3;
                @Button3.performed -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton3;
                @Button3.canceled -= m_Wrapper.m_GameWindowsActionsCallbackInterface.OnButton3;
            }
            m_Wrapper.m_GameWindowsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveL.started += instance.OnMoveL;
                @MoveL.performed += instance.OnMoveL;
                @MoveL.canceled += instance.OnMoveL;
                @MoveR.started += instance.OnMoveR;
                @MoveR.performed += instance.OnMoveR;
                @MoveR.canceled += instance.OnMoveR;
                @Shifting.started += instance.OnShifting;
                @Shifting.performed += instance.OnShifting;
                @Shifting.canceled += instance.OnShifting;
                @ButtonL.started += instance.OnButtonL;
                @ButtonL.performed += instance.OnButtonL;
                @ButtonL.canceled += instance.OnButtonL;
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
                @Button1.started += instance.OnButton1;
                @Button1.performed += instance.OnButton1;
                @Button1.canceled += instance.OnButton1;
                @Button2.started += instance.OnButton2;
                @Button2.performed += instance.OnButton2;
                @Button2.canceled += instance.OnButton2;
                @Button3.started += instance.OnButton3;
                @Button3.performed += instance.OnButton3;
                @Button3.canceled += instance.OnButton3;
            }
        }
    }
    public GameWindowsActions @GameWindows => new GameWindowsActions(this);

    // EndScreen
    private readonly InputActionMap m_EndScreen;
    private IEndScreenActions m_EndScreenActionsCallbackInterface;
    private readonly InputAction m_EndScreen_ButtonPress;
    public struct EndScreenActions
    {
        private @Player m_Wrapper;
        public EndScreenActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @ButtonPress => m_Wrapper.m_EndScreen_ButtonPress;
        public InputActionMap Get() { return m_Wrapper.m_EndScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EndScreenActions set) { return set.Get(); }
        public void SetCallbacks(IEndScreenActions instance)
        {
            if (m_Wrapper.m_EndScreenActionsCallbackInterface != null)
            {
                @ButtonPress.started -= m_Wrapper.m_EndScreenActionsCallbackInterface.OnButtonPress;
                @ButtonPress.performed -= m_Wrapper.m_EndScreenActionsCallbackInterface.OnButtonPress;
                @ButtonPress.canceled -= m_Wrapper.m_EndScreenActionsCallbackInterface.OnButtonPress;
            }
            m_Wrapper.m_EndScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ButtonPress.started += instance.OnButtonPress;
                @ButtonPress.performed += instance.OnButtonPress;
                @ButtonPress.canceled += instance.OnButtonPress;
            }
        }
    }
    public EndScreenActions @EndScreen => new EndScreenActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard/Mouse");
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
    public interface IGameWindowsActions
    {
        void OnMoveL(InputAction.CallbackContext context);
        void OnMoveR(InputAction.CallbackContext context);
        void OnShifting(InputAction.CallbackContext context);
        void OnButtonL(InputAction.CallbackContext context);
        void OnSelection(InputAction.CallbackContext context);
        void OnButton1(InputAction.CallbackContext context);
        void OnButton2(InputAction.CallbackContext context);
        void OnButton3(InputAction.CallbackContext context);
    }
    public interface IEndScreenActions
    {
        void OnButtonPress(InputAction.CallbackContext context);
    }
}
