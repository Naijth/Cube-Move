using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_look : MonoBehaviour
{
    float pyOld;
    float pxOld;
    bool third_person = false;
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        float py = Input.GetAxis("Mouse Y");
        float px = Input.GetAxis("Mouse X");
        pyOld += px * 5;
        pxOld -= py * 5;
        pxOld = Mathf.Clamp(pxOld, -90, 90);
        //ThirdPerson();
        if (!third_person)
        {
            gameObject.transform.rotation = Quaternion.Euler(pxOld, pyOld, 0);
            gameObject.transform.parent.rotation = Quaternion.Euler(0, pyOld, 0);
        }
        else
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, pyOld, 0);
        }
    }
    //void ThirdPerson()
    //{
    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        if (third_person) 
    //        {
    //            camera.transform.position = gameObject.transform.position;
    //            camera.transform.rotation = gameObject.transform.rotation;
    //            third_person = false;
    //        }
    //        else
    //        {
    //            camera.transform.position = gameObject.transform.position + new Vector3(0, 1.5f, -5);
    //            camera.transform.rotation = Quaternion.Euler(10, 0, 0);
    //            third_person = true;
    //        }
    //    }
    //}
}
