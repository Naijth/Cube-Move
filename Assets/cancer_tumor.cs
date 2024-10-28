using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancer_tumor : MonoBehaviour
{
    public cube_move cancer;
    public LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        cancer.groundCheck = Physics.CheckSphere(transform.position, 0.1f, mask);
    }
}
