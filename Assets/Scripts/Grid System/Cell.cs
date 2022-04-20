using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cell : MonoBehaviour
{
    private int _value = 0;
    private bool _canBeSet = false;
    private int _index;

    public int Index { get { return _index; } }
    public bool CabBeSet { get { return _canBeSet; } }




    //[SerializeField] public Vector2 Position;


    public Cell Create(int value, int index ,Vector2 position)
    {
        _value = value;
        _index = index;
        transform.position = position;
        return this;
    }


    private void ChangeCellColor(Color color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    public void SetCellValue(int value, Color color) // Set value of the cell and recolor it
    {
        _value = value;
        ChangeCellColor(color);
    }

    public void MarkCell(bool canBeSet,Color color)
    {
        _canBeSet = canBeSet;
        ChangeCellColor(color);
    }

    public void ClearCell()
    {
        _value = 0;
        ChangeCellColor(Color.clear);
    }
    
    private int ReturnIndex()
    {
        return _index;
    }

    public delegate void CellCallback(int index);
    public event CellCallback CellIsClicked;

    void OnMouseDown()
    {
        if (_canBeSet)
        {
            CellIsClicked?.Invoke(Index);
        }
    }
}
