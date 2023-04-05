using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DustSystem : MonoBehaviour
{
    public GameObject dust;
    private Vector2 direction;

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x != 0 || direction.y != 0)
        {
            dust.SetActive(true);
        }
        else
        {
            dust.SetActive(false);
        }
    }
}