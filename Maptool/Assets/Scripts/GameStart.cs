using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private List<GameObject> _ground = new List<GameObject>();

    /*
     * Ÿ�Ͽ� �ʿ��� ������
     * 
     * ��
     * �÷��̾��� ���� 50% ����
     * �÷��̾��� �̵��ӵ� 50% ����
     * �̵� ����
     * 
     */

    [SerializeField] private GameObject _field;
    [SerializeField] private GameObject _player;

    private void Start()
    {
        _ground.Add(_field);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < _ground.Count; ++i)
            {
                _ground[i].GetComponent<MeshCollider>().enabled = true;
            }

            Instantiate(_player);
        }

        // ���� Ȯ���ư�� ������ ����Ʈ�� �߰��ϸ鼭 �ν��Ͻÿ���Ʈ �� �ش�
    }
}
