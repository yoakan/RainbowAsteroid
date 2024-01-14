using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorManager : MonoBehaviour
{
    private Dictionary<ColorType, ColorItem> colorsMap;

    

    [SerializeField] private List<ColorItem> _colorItems;
    // Start is called before the first frame update
    private void Awake()
    {
        addColors();
    }

    private void addColors()
    {
        colorsMap = new Dictionary<ColorType, ColorItem>();
        for (int i=0;i<_colorItems.Count;i++)
        {
           
            colorsMap.Add(_colorItems[i].Type,_colorItems[i]);
        }
    }

    public ColorItem getRandomColorItem()
    {
        return _colorItems[Random.Range(0, _colorItems.Count)];
    }

    public ColorItem getColorItem(ColorType type)
    {
        return colorsMap[type];
    }
}
