using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Objects")]
    [SerializeField] private JoyStick JoystickController;
    [SerializeField] private PAnimation playerAnimatior;
    private CharacterController characterController;
    Vector3 moveVector;

    [Header("Settings")]
    [SerializeField] private int moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        moveVector = JoystickController.GetMovePosition() * moveSpeed * Time.deltaTime / Screen.width;

        moveVector.z = moveVector.y;
        moveVector.y = 0;

        playerAnimatior.ManageAnimations(moveVector);
        characterController.Move(moveVector);

    }
}