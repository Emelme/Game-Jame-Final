using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCell : MonoBehaviour
{
    public bool isBuilded = false;

    public GameObject cell;

    public GameObject Building;
    public GameObject builds;

    public Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }
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
            Building = null;

            builds = null;
            Destroy(transform.GetChild(0).gameObject);
            isBuilded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
