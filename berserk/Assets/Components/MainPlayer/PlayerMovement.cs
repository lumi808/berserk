using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MainPlayerAnimation _playerAnimation;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 1.0f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _characterController.Move(moveDirection.normalized * _speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            _playerAnimation.Walk();
        }
        else
        {
            _playerAnimation.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _playerAnimation.Slash();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerAnimation.Kick();
        }

    }
}
