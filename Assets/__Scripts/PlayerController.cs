using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem.HID;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 movement;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Transform _camTransform;

    [SerializeField] GameObject crouchPoint;

    [SerializeField] bool crouchBeingHeld;
    [SerializeField] bool crouched;
    [SerializeField] bool cantUncrouch;
    [SerializeField] float crouchTime;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        _camTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = _camTransform.forward * move.z + _camTransform.right * move.x;
        move.y = 0f;

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        if (!groundedPlayer && playerVelocity.y < .5f)
        {
            playerVelocity.y += (gravityValue) * Time.deltaTime;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }


    private void Jump()
    {
        if (groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }

    private void GetPlayerMovement(Vector2 move)
    {
        movement = move;
    }

    void OnEnable()
    {
        PlayerInput.MoveEvent += GetPlayerMovement;
    }

    void OnDisable()
    {
        PlayerInput.MoveEvent -= GetPlayerMovement;
    }

}