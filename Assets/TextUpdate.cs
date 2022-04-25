using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    [SerializeField] private GameObject _gridManager;
    private GridManager _gm;
    void Start()
    {
        _gm = _gridManager.GetComponent<GridManager>();
    }

}
