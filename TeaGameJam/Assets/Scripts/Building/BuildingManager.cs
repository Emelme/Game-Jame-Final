using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public bool isBuilding = false;

    public GameObject toBuild;

    public GameObject Grid;

    public GameObject col;

    public GameObject inHeart;

    public GameObject delete;

    public List<GameObject> containHeart;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBuilding = !isBuilding;
            if (!isBuilding && toBuild != null)
            {
                Instantiate(toBuild.GetComponent<itemBase>().toBuild, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
                toBuild = null;
            }
            Grid.SetActive(isBuilding);
        }
        if (!isBuilding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
                if (hit.collider != null && hit.collider.tag == "Enemy") Destroy(hit.transform.gameObject);
            }
        }
        if (isBuilding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
                if (hit.collider)
                {
                    if (hit.collider.tag != null && hit.collider.tag == "canBuild" && toBuild != null)
                    {
                        hit.transform.GetComponent<BuildingCell>().build();
                        toBuild = null;
                    }
                    if (hit.collider.tag == "Enemy") Destroy(hit.transform.gameObject);

                    if (hit.transform.tag == "Heart" && toBuild != null && toBuild.tag != "Heart")
                    {
                        
                        containHeart = hit.transform.parent.GetComponent<BuildingHeart>().inHeart;
                        if (inHeart != null)
                        {
                            hit.transform.parent.GetComponent<BuildingHeart>().Count();
                            foreach (GameObject i in containHeart)
                            {
                                if (toBuild != i)
                                {
                                    hit.transform.parent.GetComponent<BuildingHeart>().Count();
                                    containHeart.Add(toBuild);
                                    hit.transform.GetComponent<BuildingCell>().build();
                                    toBuild = null;
                                }
                            }
                        }
                        else
                        {
                            if (hit.transform.parent.GetComponent<BuildingHeart>().inHeart.Count < 8)
                            {
                                hit.transform.parent.GetComponent<BuildingHeart>().Count();

                                hit.transform.parent.GetComponent<BuildingHeart>().inHeart.Add(toBuild);
                                hit.transform.GetComponent<cell1>().build();
                                toBuild = null;
                            }

                        }
                        hit.transform.parent.GetComponent<BuildingHeart>().Count();
                    }
                }
            }

                if (Input.GetMouseButtonDown(1))
                {
                    
                    RaycastHit2D hits = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
                    if (hits.collider)
                    {
                    
                        if (hits.collider.tag != null && hits.collider.tag == "canBuild" && hits.transform.transform.GetChild(0) != null)
                            {
                                Instantiate(hits.transform.transform.GetChild(0).GetComponent<itemBase>().toBuild, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                                hits.transform.GetComponent<BuildingCell>().destroy();
                            }

                        if(hits.collider.tag == "Heart" && hits.transform.transform.GetChild(0) != null)
                            {
                                Instantiate(hits.transform.transform.GetChild(0).GetComponent<itemBase>().toBuild, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
                                hits.transform.GetComponent<cell1>().destroy();
                            }
                    }
                }
            }
        }
    }