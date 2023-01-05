using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    /*
     * 타일에 필요한 정보들
     * 
     * 색
     * 플레이어의 투명도 50% 감소
     * 플레이어의 이동속도 50% 감소
     * 이동 유무
     * 
     * */

    private const float NORMAL = 1f;
    private const float HALF = 0.5f;

    private Color _whiteHalf = new Color(1f, 1f, 1f, 0.5f);
    private Color _greenHalf = new Color(0f, 1f, 0f, 0.5f);
    private Color _blueHalf = new Color(0f, 0f, 1f, 0.5f);
    private Color _blackHalf = new Color(0f, 0f, 0f, 0.5f);

    private Color _tileColor;
    public Color TileColor { get { return _tileColor; } private set { _tileColor = value; } }

    private Color _tileColorHalf;
    public Color TileColorHalf { get { return _tileColorHalf; } private set { _tileColorHalf = value; } }

    private float _playerColorAlpha;
    public float PlayerColorAlpha { get { return _playerColorAlpha; } private set { _playerColorAlpha = value; } }

    private float _playerSpeed;
    public float PlayerSpeed { get { return _playerSpeed; } private set { _playerSpeed = value; } }

    private bool _canPass;
    public bool CanPass { get { return _canPass; } private set { _canPass = value; } }

    private void Awake()
    {
        _tileColor = Color.white;
        _tileColorHalf = _whiteHalf;
        _playerColorAlpha = NORMAL;
        _playerSpeed = NORMAL;
        _canPass = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _tileColor = Color.white;
            _tileColorHalf = _whiteHalf;
            _playerColorAlpha = NORMAL;
            _playerSpeed = NORMAL;
            _canPass = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _tileColor = Color.green;
            _tileColorHalf = _greenHalf;
            _playerColorAlpha = HALF;
            _playerSpeed = NORMAL;
            _canPass = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _tileColor = Color.blue;
            _tileColorHalf = _blueHalf;
            _playerColorAlpha = NORMAL;
            _playerSpeed = HALF;
            _canPass = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _tileColor = Color.black;
            _tileColorHalf = _blackHalf;
            _playerColorAlpha = NORMAL;
            _playerSpeed = NORMAL;
            _canPass = false;
        }
    }
}
