using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private TileInfo _tileInfo;
    private Collider[] colliders = new Collider[2];
    private Color basicsColor = new Color(1f, 1f, 1f, 0f);

    private bool _isStart;

    private void Update()
    {
        if (!_isStart)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                _isStart = true;
            }
        }

        Ray ray;
        RaycastHit hit;
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && !_isStart)
        {
            Tile tile = hit.collider.gameObject.GetComponent<Tile>();
            if (tile.IsSelect)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.gameObject.GetComponent<MeshRenderer>().material.color == _tileInfo.TileColor)
                    {
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = basicsColor;
                        tile.PlayerSpeed = 1f;
                        tile.IsSelect = false;
                        return;
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = _tileInfo.TileColor;
                        tile.PlayerSpeed = _tileInfo.PlayerSpeed;
                        tile.IsSelect = true;
                        return;
                    }
                }

                if (colliders[0] != null)
                {
                    colliders[1] = hit.collider;
                    if (!colliders[0].GetComponent<Tile>().IsSelect)
                    {
                        colliders[0].GetComponent<MeshRenderer>().material.color = basicsColor;
                    }
                    colliders[0] = colliders[1];
                    colliders[1] = null;

                    return;
                }
                
            }

            if (colliders[0] == null && !hit.collider.gameObject.GetComponent<Tile>().IsSelect)
            {
                colliders[0] = hit.collider;
            }
            else
            {
                colliders[1] = hit.collider;
                if (!colliders[0].GetComponent<Tile>().IsSelect)
                {
                    colliders[0].GetComponent<MeshRenderer>().material.color = basicsColor;   
                }
                colliders[0] = colliders[1];
                colliders[1] = null;
            }

            MeshRenderer meshRenderer = hit.collider.gameObject.GetComponent<MeshRenderer>();

            meshRenderer.material.color = _tileInfo.TileColorHalf;
            
            if (Input.GetMouseButtonDown(0))
            {
                meshRenderer.material.color = _tileInfo.TileColor;
                tile.IsSelect = true;
                tile.PlayerSpeed = _tileInfo.PlayerSpeed;
            }


        }
    }
}
