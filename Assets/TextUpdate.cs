using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    void Start()
    {
        _gridManager = GetComponent<GridManager>();
    }

    // Update is 
}
