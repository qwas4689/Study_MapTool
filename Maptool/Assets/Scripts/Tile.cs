using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    private bool _isSelect;
    public bool IsSelect { get; set; }

    private Color basicsColor = new Color(1f, 1f, 1f, 0f);
    private Color _whiteHalf = new Color(1f, 1f, 1f, 0.5f);
    private Color _greenHalf = new Color(0f, 1f, 0f, 0.5f);
    private Color _blueHalf = new Color(0f, 0f, 1f, 0.5f);
    private Color _blackHalf = new Color(0f, 0f, 0f, 0.5f);

    private MeshRenderer _meshRenderer;
    private Collider _collider;

    private float _playerSpeed;
    public float PlayerSpeed { get { return _playerSpeed; } set { _playerSpeed = value; } }

    private bool _isStart;

    public Action Click;
    public Action ResetClick;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (!_isStart)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                _meshRenderer = GetComponent<MeshRenderer>();

                if (_meshRenderer.material.color == basicsColor || _meshRenderer.material.color == _whiteHalf || _meshRenderer.material.color == _greenHalf || _meshRenderer.material.color == _blueHalf || _meshRenderer.material.color == _blackHalf)
                {
                    _meshRenderer.material.color = Color.white;
                    _collider.isTrigger = true;
                }
                if (_meshRenderer.material.color == Color.black)
                {
                    _collider.isTrigger = false;
                }
                _isStart = true;
            }
        }

    }
}
