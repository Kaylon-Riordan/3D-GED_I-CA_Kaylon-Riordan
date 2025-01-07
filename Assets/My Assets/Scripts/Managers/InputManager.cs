using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private PlayerInputActions inputs;
    public InputAction leftClick;
    public InputAction rightClick;

    public delegate void LeftClickDown();
    public static LeftClickDown leftClickDown;
    public delegate void LeftClickUp();
    public static LeftClickUp leftClickUp;
    public delegate void RightClickDown();
    public static RightClickDown rightClickDown;
    public delegate void RightClickUp();
    public static RightClickUp rightClickUp;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        inputs = new PlayerInputActions();
    }
    private void OnEnable()
    {
        leftClick = inputs.Player.LeftClick;
        leftClick.Enable();
        leftClick.performed += LeftClickPressed;
        leftClick.canceled += LeftClickReleased;

        rightClick = inputs.Player.RightClick;
        rightClick.Enable();
        rightClick.performed += RightClickPressed;
        rightClick.canceled += RightClickReleased;
    }
    private void OnDisable()
    {
        leftClick.performed -= LeftClickPressed;
        leftClick.canceled -= LeftClickReleased;
        leftClick.Disable();

        rightClick.performed -= RightClickPressed;
        rightClick.canceled -= RightClickReleased;
        rightClick.Disable();
    }

    /// <summary>
    /// Called when player left clicks
    /// </summary>
    /// <param name="context"> Informs when the left click input is activated </param>
    public void LeftClickPressed(InputAction.CallbackContext context)
    {
        if (leftClickDown != null)
        {
            leftClickDown();
        }
    }

    /// <summary>
    /// Called when player releases left click
    /// </summary>
    /// <param name="context"> Informs when the left click input is activated </param>
    public void LeftClickReleased(InputAction.CallbackContext context)
    {
        if (leftClickUp!= null)
        {
            leftClickUp();
        }
    }

    /// <summary>
    /// Called when player right clicks
    /// </summary>
    /// <param name="context"> Informs when the right click input is activated </param>
    public void RightClickPressed(InputAction.CallbackContext context)
    {
        if (rightClickDown != null)
        {
            rightClickDown();
        }
    }

    /// <summary>
    /// Called when player releases right click
    /// </summary>
    /// <param name="context"> Informs when the right click input is activated </param>
    public void RightClickReleased(InputAction.CallbackContext context)
    {
        if(rightClickUp != null)
        {
            rightClickUp();
        }
    }
}