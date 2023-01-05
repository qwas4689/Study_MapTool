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

    private float _playerColorAlpha;
    public float PlayerColorAlpha { get { return _playerColorAlpha; } set { _playerColorAlpha = value; } }

    private float _playerSpeed;
    public float PlayerSpeed { get { return _playerSpeed; } set { _playerSpeed = value; } }

    private bool _canPass;
    public bool CanPass { get { return _canPass; } set { _canPass = value; } }


    public Action Click;
    public Action ResetClick;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (!_isSelect && Input.GetKeyDown(KeyCode.P))
        {
            _meshRenderer = GetComponent<MeshRenderer>();

            if (_meshRenderer.material.color == basicsColor || _meshRenderer.material.color == _whiteHalf || _meshRenderer.material.color == _greenHalf || _meshRenderer.material.color == _blueHalf || _meshRenderer.material.color == _blackHalf)
            {
                _meshRenderer.material.color = Color.white;
            }
        }

        if (!_canPass)
        {
            _collider.isTrigger = false;
        }
    }
}
