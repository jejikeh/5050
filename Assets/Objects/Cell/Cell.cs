using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private bool _canBeSet;

    // Update is called once per frame
    void Update()
    {
        if(_canBeSet)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
