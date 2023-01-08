using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public class Tile : MonoBehaviour
{
    private bool _isSelect;
    public bool IsSelect { get { return _isSelect; } set { _isSelect = value; } }

    private Color basicsColor = new Color(1f, 1f, 1f, 0f);
    private Color _whiteHalf = new Color(1f, 1f, 1f, 0.5f);
    private Color _greenHalf = new Color(0f, 1f, 0f, 0.5f);
    private Color _blueHalf = new Color(0f, 0f, 1f, 0.5f);
    private Color _blackHalf = new Color(0f, 0f, 0f, 0.5f);

    private float _tileColorR;
    private float _tileColorG;
    private float _tileColorB;
    private float _tileColorA;

    private string _tileName;
    private string _groupName;
    private const string _newline = "----------------------";

    private string _dataPath;
    private DirectoryInfo _directoryInfo;

    private StreamWriter _streamWriter;
    private StreamReader _streamReader;

    private MeshRenderer _meshRenderer;
    private Collider _collider;

    private float _playerSpeed;
    public float PlayerSpeed { get { return _playerSpeed; } set { _playerSpeed = value; } }

    private bool _isStart;

    public Action Click;
    public Action ResetClick;

    private void Awake()
    {
        _dataPath = Application.dataPath;
        _directoryInfo = new DirectoryInfo(_dataPath);
    }

    private void Start()
    {
        SaveTileName();

        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!_isStart)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (_meshRenderer.material.color == basicsColor || _meshRenderer.material.color == _whiteHalf || _meshRenderer.material.color == _greenHalf || _meshRenderer.material.color == _blueHalf || _meshRenderer.material.color == _blackHalf)
                {
                    _meshRenderer.material.color = Color.white;
                    _collider.isTrigger = true;
                }
                if (_meshRenderer.material.color == Color.black)
                {
                    _collider.isTrigger = false;
                }

                SaveTileColor();

                if (_playerSpeed == 0)
                {
                    _playerSpeed = 1f;
                }

                _isStart = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SaveMap();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadMap();
        }
    }

    private void SaveTileColor()
    {
        _tileColorR = _meshRenderer.material.color.r;
        _tileColorG = _meshRenderer.material.color.g;
        _tileColorB = _meshRenderer.material.color.b;
        _tileColorA = _meshRenderer.material.color.a;
    }

    private void SaveTileName()
    {
        _groupName = transform.parent.gameObject.name;
        _tileName = gameObject.name;
    }

    private void SaveMap()
    {
        _streamWriter = new StreamWriter(_dataPath + "/" + _groupName + ".txt", true);

        _streamWriter.WriteLine(_tileName);
        _streamWriter.WriteLine(_tileColorR);
        _streamWriter.WriteLine(_tileColorG);
        _streamWriter.WriteLine(_tileColorB);
        _streamWriter.WriteLine(_tileColorA);
        _streamWriter.WriteLine(_playerSpeed);
        _streamWriter.WriteLine(_newline);

        _streamWriter.Close();
    }

    private void LoadMap()
    {
        _streamReader = new StreamReader(_dataPath + "/" + _groupName + ".txt");

        while(true)
        { 
            if (_tileName == _streamReader.ReadLine())
            {
                _tileColorR = float.Parse(_streamReader.ReadLine());
                _tileColorG = float.Parse(_streamReader.ReadLine());
                _tileColorB = float.Parse(_streamReader.ReadLine());
                _tileColorA = float.Parse(_streamReader.ReadLine());
                _playerSpeed = float.Parse(_streamReader.ReadLine());
                _streamReader.ReadLine();

                _streamReader.Close();

                _meshRenderer.material.color = new Color(_tileColorR, _tileColorG, _tileColorB, _tileColorA);

                _isSelect = true;

                break;
            }
        }
    }
}
