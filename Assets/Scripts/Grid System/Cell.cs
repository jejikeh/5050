using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cell : MonoBehaviour
{
    public int _value;
    public bool _r;
    [SerializeField] public Vector2 Position;
    public void Create(int value,Vector2 position, GameObject cellObject)
    {
        Position = position;
        _value = value;
        cellObject.transform.position = Position;
    }
    

    public void FillCell(List<Cell> _grid,int value,Color color)
    {
        _value = value;
        GetComponent<SpriteRenderer>().color = color;
        GetAviableCells(_grid, this.transform.position);
        
    }
    private void GetAviableCells(List<Cell> _grid,Vector2 position)
    {
        foreach (Cell cell in _grid)
        {
            if (cell.Position.x + 2 == position.x && cell.Position.y + 1 == position.y || cell.Position.x + 1 == position.x && cell.Position.y + 2 == position.y || cell.Position.x - 1 == position.x && cell.Position.y + 2 == position.y || cell.Position.x - 2 == position.x && cell.Position.y + 1 == position.y || cell.Position.x - 2 == position.x && cell.Position.y - 1 == position.y || cell.Position.x - 1 == position.x && cell.Position.y - 2 == position.y || cell.Position.x + 1 == position.x && cell.Position.y - 2 == position.y || cell.Position.x + 2 == position.x && cell.Position.y - 1 == position.y && cell._r == false)
            {
                cell.ColorCell(Color.yellow);
            }
            else if(cell.Position.x > -3 && cell.Position.x < 3 && cell.Position.y > -3 && cell.Position.y < 3)
            {
                cell.ColorCell(Color.white);
            }else
            {
                cell.ColorCell(Color.red);
            }

            if (cell.Position == position)
            {
                cell.ColorCell(Color.green);
            }

            if(cell._r == true)
            {
                cell.ColorCell(Color.black);
            }
        }
    }

    public void FindGreen()
    {
        foreach (Cell cell in GridManager._grid)
        {
            if(cell.GetComponent<SpriteRenderer>().color == Color.green)
            {
                cell._r = true;
            }
        }
    }

    public void OnMouseDown()
    {
        if (GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            if (Position.x > -3 && Position.x < 3 && Position.y > -3 && Position.y < 3)
            {
                FindGreen();
                GridManager.Value++;
                Debug.Log(GridManager.Value);
                FillCell(GridManager._grid, GridManager.Value, Color.yellow);

            }else
            {
                FindGreen();
                GridManager.Value--;
                Debug.Log(GridManager.Value);
                FillCell(GridManager._grid, GridManager.Value, Color.yellow);
            }
        }

        
    }

    public void ColorCell(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
