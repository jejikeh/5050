using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGrid : MonoBehaviour
{
    [SerializeField] private GameObject _cell;
    [SerializeField] private int _row;
    [SerializeField] private int _column;
    
    private Vector2 _startPoint;
    private Vector2 _offset;
    void Start()
    {
        _offset.x = -_column / 2 + 0.5f;
        _offset.y = -_row / 2 + 0.5f;
        for (int i = 0; i < _column; i++)
        {
            for (int j = 0; j < _row; j++)
            {
                GameObject newCell = Instantiate(_cell) as GameObject;
                _startPoint.x = j;
                _startPoint.y = i;
                newCell.transform.position = _startPoint + _offset;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
