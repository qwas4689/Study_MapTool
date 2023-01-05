using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Vector3 offsetPosition = new Vector3(Input.GetAxisRaw(_horizontal), 0f, Input.GetAxisRaw(_vertical)).normalized;
        Vector3 movePosition = _moveSpeed * Time.deltaTime * offsetPosition + _rigidBody.position;

        _rigidBody.MovePosition(movePosition);
    }
}
