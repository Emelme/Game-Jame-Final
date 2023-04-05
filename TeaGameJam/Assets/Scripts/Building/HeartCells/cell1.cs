using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell1 : MonoBehaviour
{
    public GameObject inHeart;
    public bool isBuilded = false;

    public GameObject cell;

    public GameObject Building;
    public GameObject builds;

    public Vector3 pos;

    public void build()
    {
        if (!isBuilded)
        {
            Building = FindObjectOfType<BuildingManager>().toBuild;

            builds = Instantiate(Building, cell.transform.position, Quaternion.identity);
            builds.transform.SetParent(cell.transform);
            isBuilded = true;
        }
    }

    public void destroy()
    {
        if (isBuilded)
        {
            transform.parent.GetComponent<BuildingHeart>().inHeart.Remove(Building);
            Building = null;

            builds = null;
            
            transform.parent.GetComponent<BuildingHeart>().Count();
            Destroy(transform.GetChild(0).gameObject);
            isBuilded = false;
        }
    }
}
