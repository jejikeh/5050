using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private int _row, _column;

    [SerializeField] public static int Value = 0;

    public static List<Cell> _grid = new List<Cell>();
    
    private void InitGrid()
    {
        for(int i = 0; i < _column*2; i++)
        {
            for(int j = 0; j < _row*2; j++)
            {
                GameObject g = Instantiate(_cellPrefab);
                g.GetComponent<Cell>().Create(0, new Vector2(i - (_column*2 / 2) + 0.5f, j - (_row*2 / 2) + 0.5f),g);
                _grid.Add(g.GetComponent<Cell>());
            }
        }
    }

    private void SetFirstCell()
    {
        InitGrid();
        int index = Random.Range(0, _column*2 * _row*2);
        if(_grid[index].Position.x > -3 && _grid[index].Position.x < 3 && _grid[index].Position.y > -3 && _grid[index].Position.y < 3)
        {
            _grid[index].FillCell(_grid,Value++,Color.green);
        }else
        {
            SetFirstCell();
        }
    }


    private void Start()
    {
        InitGrid();
        SetFirstCell();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetFirstCell();
            Value = 0;
        }
    }


}
