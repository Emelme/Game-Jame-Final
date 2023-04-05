using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delete());
    }

    public IEnumerator delete()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
