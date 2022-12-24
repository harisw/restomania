using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBox : MonoBehaviour
{
    public GameObject itemPrefab;
    public int itemStock = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool hasStock() {
        return itemStock > 0;
    }

    public GameObject getItem() {
        ReduceItem();
        return itemPrefab;
    }
    private void ReduceItem() {
        itemStock--;
    }   
}