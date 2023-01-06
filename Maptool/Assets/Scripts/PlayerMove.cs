using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private float _moveSpeed;

    private float _defaultMoveSpeed; 

    [SerializeField] private MeshRenderer _meshRenderer;

    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private Color _redHalf = new Color(1f, 0f, 0f, 0.5f);

    private void Awake()
    {
        _defaultMoveSpeed = _moveSpeed;
    }

    private void Update()
    {
        Vector3 offsetPosition = new Vector3(Input.GetAxisRaw(_horizontal), 0f, Input.GetAxisRaw(_vertical)).normalized;
        Vector3 movePosition = _moveSpeed * Time.deltaTime * offsetPosition + _rigidBody.position;

        _rigidBody.MovePosition(movePosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.GetComponent<Tile>().PlayerSpeed);
        if (other.gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
        {
            _meshRenderer.material.color = _redHalf;
            _moveSpeed = _defaultMoveSpeed;
        }

        else if (other.gameObject.GetComponent<MeshRenderer>().material.color == Color.blue)
        {
            if (_moveSpeed != _defaultMoveSpeed)
            {
                return;
            }
            _meshRenderer.material.color = Color.red;
            _moveSpeed *= other.gameObject.GetComponent<Tile>().PlayerSpeed;
        }

        else if (other.gameObject.GetComponent<MeshRenderer>().material.color == Color.white)
        {
            _meshRenderer.material.color = Color.red;
            _moveSpeed = _defaultMoveSpeed;
        }
    }
}
