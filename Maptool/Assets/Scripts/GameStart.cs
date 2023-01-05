using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private List<GameObject> _ground = new List<GameObject>();

    /*
     * 타일에 필요한 정보들
     * 
     * 색
     * 플레이어의 투명도 50% 감소
     * 플레이어의 이동속도 50% 감소
     * 이동 유무
     * 
     */

    [SerializeField] private GameObject _field;
    [SerializeField] private GameObject _player;

    private bool _isStart;

    private void Start()
    {
        _ground.Add(_field);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !_isStart)
        {
            for (int i = 0; i < _ground.Count; ++i)
            {
                _ground[i].GetComponent<MeshCollider>().enabled = true;
            }

            Instantiate(_player);

            _isStart = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // 옆의 확장버튼을 누르면 리스트에 추가하면서 인스턴시에이트 해 준다
    }
}
