using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solt : MonoBehaviour
{
    [SerializeField] Image image;
    private item _item;
    public int itemId;
    public Stocks _stocks;
    public int stockId;
    public item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else { image.color = new Color(1, 1, 1, 0); }

        }
    }
    public Stocks stocks
    {
        get { return _stocks; }
        set
        {
            _stocks = value;
            if (_stocks != null)
            {
                image.sprite = stocks.image;
                image.color = new Color(1, 1, 1, 1);
            }
            else { image.color = new Color(1, 1, 1, 0); }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
