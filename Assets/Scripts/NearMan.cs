using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearMan : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.position);
        if (dis < 6)
        {
            transform.localScale = new Vector3(2, 2, 2);
            
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
