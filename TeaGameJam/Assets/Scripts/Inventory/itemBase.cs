using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBase : MonoBehaviour
{
    public GameObject itemPref;

    public bool Buildable = false;

    public int size = 1;

    public GameObject mainCell;
    public int inCell;

    public GameObject toBuild;

    public int itemID;

    public bool canPickup = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Builds()
    {
        Debug.Log("1");
        inCell = transform.parent.gameObject.GetComponent<InvenoryCell>().ammount;

        while (transform.parent.gameObject.GetComponent<InvenoryCell>().ammount > 0)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                break;
            }
            if (FindObjectOfType<BuildingManager>().toBuild == null)
            {
                FindObjectOfType<BuildingManager>().toBuild = toBuild;
                transform.parent.gameObject.GetComponent<InvenoryCell>().ammount -= 1;
                Builds();
            }
            else break;
        }

        if(transform.parent.gameObject.GetComponent<InvenoryCell>().ammount == 0)
        {
            transform.parent.gameObject.GetComponent<InvenoryCell>().ammount = 0;
            transform.parent.gameObject.GetComponent<InvenoryCell>().containGO = null;

            //FindObjectOfType<BuildingManager>().toBuild = null;
            Destroy(gameObject);
        }
       
    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.transform.tag == "Player" && canPickup)
        {
            
            if (FindObjectOfType<InventoryManager>().i < FindObjectOfType<InventoryManager>().cells.Length)
            {
                FindObjectOfType<InventoryManager>().item = itemPref;
                FindObjectOfType<InventoryManager>().itemSize = size;
                FindObjectOfType<InventoryManager>().currObject = gameObject;
                FindObjectOfType<InventoryManager>().AddItem();
            }
        }
    }
    public void Update()
    {

    }
}
