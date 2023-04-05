using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] cells;

    public GameObject item;

    public int i = 0;
    public int a = 0;

    public int itemSize;

    public GameObject currObject;
    public bool placed;
    public void AddItem()
    {
        i = 0;
        a = 0;
        if (i < cells.Length)
        {

            while (i < cells.Length)
            {
                a = 0;
                placed = false;
                while (a < cells.Length)
                {
                    
                    if (cells[i].GetComponent<InvenoryCell>().containGO == item && cells[i].GetComponent<InvenoryCell>().ammount < 10)
                    {
                        Destroy(currObject);
                        cells[i].GetComponent<InvenoryCell>().ammount += itemSize;
                        placed = true;
                        break;

                    }
                    a++;
                }

                if (placed) break;
                
                if (cells[i].transform.childCount == 0 && !placed)
                {
                    Destroy(currObject);
                    cells[i].GetComponent<InvenoryCell>().containGO = item;
                    Instantiate(item, cells[i].transform);
                    cells[i].GetComponent<InvenoryCell>().ammount += itemSize;
                    break;
                }
                a = 0;
                i++;
                
            }
            i = 0;
            
        }
        
    }
   
    //public void OnTriggerEnter2D(Collider2D col)
    //{
    //    if(col.transform.tag == "pickUp")
    //    {
    //        if(i < cells.Length)
    //        {
    //            item = col.transform.GetComponent<itemBase>().itemPref;
    //            itemSize = col.transform.GetComponent<itemBase>().size;
    //            currObject = col.gameObject;
    //            AddItem();
    //        }
    //    }
    //}
}

