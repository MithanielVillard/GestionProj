using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class InputManager : MonoBehaviour
{
    public static Interactable CurrentHover = null;
    
    private Camera _camera;
    private PlayerMovement _playerMovement;
    //---------------------------

    private void Start()
    {
        _camera = Camera.main;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void OnMouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (CurrentHover == null)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                    _playerMovement.Move(hit.point);
            }
        }
    }
}
