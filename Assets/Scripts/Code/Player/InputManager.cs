using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class InputManager : MonoBehaviour
{
    private Interactable _currentHover;
    private RaycastHit _hit;
    
    private Camera _camera;
    private PlayerMovement _playerMovement;
    //---------------------------

    private void Start()
    {
        _camera = Camera.main;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit))
        {
            if (_hit.transform.TryGetComponent(out Interactable interactable))
            {
                _currentHover = interactable;
                interactable.OnHover();
                return;
            }

            if (_currentHover)
            {
                _currentHover.OnLeaverHover();
                _currentHover = null;
            }
        }
    }

    public void OnMouseClick(InputAction.CallbackContext ctx)
    {
        if (_currentHover == null)
        {
            _playerMovement.Move(_hit.point, Test);
        }
        else _currentHover.OnInteract(_playerMovement);
    }

    private void Test()
    {
        print("Je suis arrivé");
    }
}
