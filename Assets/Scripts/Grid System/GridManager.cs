using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private int _maxRow, _maxColumn;
    [SerializeField] private Camera _camera;
    private int _score = 0;
    public int Score { get { return _score; } }

    private List<List<Cell>> _grid = new List<List<Cell>>();

    [System.Serializable]
    public class CellSettings
    {
        public bool CanSet;
        public Color Color;

        public CellSettings(bool canSet, Color color)
        {
            CanSet = canSet;
            Color = color;
        }

    }
    [SerializeField] private CellSettings _unsetCellButCanBe = new CellSettings(true, Color.yellow);
    [SerializeField] private CellSettings _unsetCellButCantBe = new CellSettings(false, Color.red);
    [SerializeField] private CellSettings _setCellButCanBe = new CellSettings(true, Color.gray);
    [SerializeField] private CellSettings _setCellButCantBe = new CellSettings(false, Color.black);
    [SerializeField] private CellSettings _selectedCell = new CellSettings(false, Color.green);


    private void Start()
    {
        InitGrid(Random.Range(3,_maxRow), Random.Range(3, _maxColumn));
    }

    private void InitGrid(int row, int column)
    {
        foreach (Cell cell in _grid)
        {
            cell.DeleteCell();
            cell.ClearCell();
        }

        _score = 0;
        _grid = new List<List<Cell>>();

        for (int i = 0; i < row; i++) // 
        {
            _grid.Add(new List<Cell>());
            for(int j = 0; j < column; j++) // 
            {
                if(_cellPrefab.GetComponent<Cell>())
                {
                    GameObject cell = Instantiate(_cellPrefab); // Create a new Instance
                    _grid[i].Add(cell.GetComponent<Cell>().Create(_score,_grid.Count,new Vector2(transform.position.x + j,transform.position.y - i)));
                    //SubscribeToEventOnClick();
                    cell.GetComponent<Cell>().CellIsClicked += Cell_CellIsClicked;
                }
            }
        }
        _camera.transform.position = new Vector3(row / 2,column/2, -10);

        SetCell(-1);
    }

    public void SetCell(int row,int collumn)
    {
        if (row < 0)
        {
            int randomIndex = Random.Range(0, _grid.Count);
            _grid[randomIndex][Random.Range(0,_grid[randomIndex].Count)].SetCellValue(1, Color.green);
            CheckAviableCells(randomIndex);
        }else
        {
            _grid[row][collumn].SetCellValue(_score, Color.green);
            CheckAviableCells();

        }
    }

    public void CheckAviableCells(int index) // 
    {
        for(int i = 0; i < _grid.Count; i++) // 
        {
            if (Mathf.Abs(_grid[index].transform.position.x - _grid[i].transform.position.x) == 1 && // check letter L
                Mathf.Abs(_grid[index].transform.position.y - _grid[i].transform.position.y) == 2 ||
                Mathf.Abs(_grid[index].transform.position.x - _grid[i].transform.position.x) == 2 &&
                Mathf.Abs(_grid[index].transform.position.y - _grid[i].transform.position.y) == 1)
            {
                if (_grid[i].Value == 0)
                {
                    _grid[i].MarkCell(_unsetCellButCanBe);
                }
                else
                {
                    _grid[i].MarkCell(_setCellButCanBe);
                }
            }
            else if (Mathf.Abs(_grid[index].transform.position.x - _grid[i].transform.position.x) == 0 &&
                     Mathf.Abs(_grid[index].transform.position.y - _grid[i].transform.position.y) == 0)
            {
                _grid[i].MarkCell(_selectedCell);
            }
            else if (_grid[i].Value != 0)
            {
                _grid[i].MarkCell(_setCellButCantBe);
            }
            else // 
            {
                _grid[i].MarkCell(_unsetCellButCantBe);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InitGrid(Random.Range(3, _maxRow), Random.Range(3, _maxColumn));
        }
        
        
    }

    private void Cell_CellIsClicked(int index)
    {
        if(_grid[index].Value == 0)
        {
            _score++;        
        }else
        {
            _score--;
        }
        SetCell(index);
        // Debug.Log(_score);
    }
}
