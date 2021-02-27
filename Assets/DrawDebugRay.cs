using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class DrawDebugRay : MonoBehaviour
{
    public float lenght=10;
    private void Update()
    {
        Debug.DrawRay(transform.position,transform.forward*lenght,Color.red, 0,true);
    }
}
