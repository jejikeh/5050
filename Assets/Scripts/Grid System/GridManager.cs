using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private int _row, _column;
    [SerializeField] public static int Value = 1;


    private List<Cell> _grid = new List<Cell>();
    
    private void InitGrid()
    {
        for(int i = _row; i > 0; i--)
        {
            for(int j = 0; j < _column; j++) // ???????? ??? ?.? ??? ???????
            {
                if(_cellPrefab.GetComponent<Cell>())
                {
                    GameObject cell = Instantiate(_cellPrefab); // Create a new Instance
                    _grid.Add(cell.GetComponent<Cell>().Create(0,_grid.Count,new Vector2(j - (_row/2) + 0.5f , i - (_column/2) - 0.5f)));
                }
            }
        }
    }

    public void SetCell(int index)
    {
        if (index < 0)
        {
            _grid[Random.Range(0, _column * _row)].SetCellValue(Value, Color.green);
            CheckAviableCells(_grid[Random.Range(0, _column * _row)]);
        }else
        {
            _grid[index].SetCellValue(Value, Color.green);
            CheckAviableCells(_grid[index]);

        }
    }

    public void CheckAviableCells(Cell selectedCell) // 
    {
        foreach(Cell cell in _grid)
        {
            if(cell == selectedCell)
            {
                for(int i = 0; i < _grid.Count; i++) // ??????? ??????
                {
                    if(Mathf.Abs(cell.transform.position.x - _grid[i].transform.position.x) == 1 && // ???????? ?????? ?
                       Mathf.Abs(cell.transform.position.y - _grid[i].transform.position.y) == 2 || 
                       Mathf.Abs(cell.transform.position.x - _grid[i].transform.position.x) == 2 &&
                       Mathf.Abs(cell.transform.position.y - _grid[i].transform.position.y) == 1 )
                    {
                        _grid[i].MarkCell(true,Color.yellow);

                    }
                    else if (Mathf.Abs(cell.transform.position.x - _grid[i].transform.position.x) == 0 && // ???? ????????? ??????
                             Mathf.Abs(cell.transform.position.y - _grid[i].transform.position.y) == 0 )
                    {
                        _grid[i].MarkCell(false, Color.green);
                    }
                    else // ??? ?????????
                    {
                        _grid[i].MarkCell(false, Color.red);
                    }
                }
            }
        }
    }

    private void Start()
    {
        InitGrid();
        SetCell(-1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach(Cell cell in _grid)
            {
                cell.ClearCell();
            }
            SetCell(-1);
        }

        foreach(Cell cell in _grid)
        {
            cell.CellIsClicked += Cell_CellIsClicked;
        }
    }

    private void Cell_CellIsClicked(int index)
    {
        SetCell(index);
    }
}
