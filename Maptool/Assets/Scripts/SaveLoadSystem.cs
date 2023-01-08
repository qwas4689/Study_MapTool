using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] private InputField _saveMapName;
    [SerializeField] private InputField _loadMapName;

    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private Tile[] _tile;

    private void Start()
    {
       
    }
}
