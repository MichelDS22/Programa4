using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float smooth = 4f;
    Vector3 newdist;
   
    // Start is called before the first frame update
    void Start()
    {
        newdist = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 posobj = target.position + newdist;
        transform.position = Vector3.Lerp(transform.position, posobj, smooth * Time.deltaTime); //lerp = interpolar
    }
}
