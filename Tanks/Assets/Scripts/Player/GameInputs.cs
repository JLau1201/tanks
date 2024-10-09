using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{

    public static GameInputs Instance { get; private set; }

    public event EventHandler OnShootInput;
    public event EventHandler OnBombInput;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        // Subscribe to input events
        playerInputActions.Player.Shoot.performed += Shoot_performed;
        playerInputActions.Player.Bomb.performed += Bomb_performed;
    }

    private void Bomb_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnBombInput?.Invoke(this, EventArgs.Empty);
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnShootInput?.Invoke(this, EventArgs.Empty);
    }


    // Return movement input vector normalized
    public Vector2 GetMovementNormalized() {
        return playerInputActions.Player.Move.ReadValue<Vector2>().normalized;
    }
}
