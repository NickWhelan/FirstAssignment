using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
    Rigidbody obj;
    bool pickedup, canpickup;
    short clicks=0;
    void OnTriggerEnter(Collider col)
    {
            if ((col.gameObject.name == "Box(Clone)" || col.gameObject.name == "Box")&& clicks ==0)
            {
                //print("hit");
                obj = col.gameObject.GetComponent<Rigidbody>();
                canpickup = true;
            }
    }
    void OnTriggerExit(Collider col)
    {
        if ((col.gameObject.name == "Box(Clone)"|| col.gameObject.name == "Box") && !pickedup)
        {
            //print("leave");
            canpickup = false;
        }
    }
    void Pickedup()
    {
        if (Input.GetKeyDown(KeyCode.E)&& obj !=null){
            if (!pickedup)
            {
                obj.GetComponent<Rigidbody>().useGravity = false;
                obj.GetComponent<Rigidbody>().freezeRotation = true;
                //obj.GetComponent<BoxCollider>().enabled = false;
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                pickedup = true;
                clicks = 1;
            }
            else if (pickedup)
            {
                obj.GetComponent<Rigidbody>().useGravity = true;
               // obj.GetComponent<BoxCollider>().enabled = true;
                obj.GetComponent<Rigidbody>().freezeRotation = false;
                pickedup = false;
                clicks = 0;
                obj.velocity = transform.TransformDirection(new Vector3(0, 0, 10));
            }
        }
    }
    void Update() {
        Pickedup();
        if (pickedup)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
        }
    }
}
