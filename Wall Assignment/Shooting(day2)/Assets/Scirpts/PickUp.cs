using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
    Rigidbody obj;
    public GameObject gun, picksquare;
    RaycastHit hit;
    bool pickedup, canpickup;
    short clicks=0;
    Collider col;
    void Pickedup()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(gun.transform.position, fwd * 2, Color.white, 5f);
        if (Physics.Raycast(gun.transform.position, fwd * 2, out hit, 2f))
        {
            if ((hit.collider.gameObject.name == "Box(Clone)" || hit.collider.gameObject.name == "Box" || hit.collider.gameObject.name == "Box 2"))
            {
                obj = hit.collider.gameObject.GetComponent<Rigidbody>();
                canpickup = true;
            }
            else canpickup = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!pickedup && canpickup && obj!=null)
            {
                obj.GetComponent<Rigidbody>().useGravity = false;
                obj.GetComponent<Rigidbody>().freezeRotation = true;
                //obj.GetComponent<BoxCollider>().enabled = false;
                obj.transform.position = picksquare.transform.position;
                obj.transform.rotation = picksquare.transform.rotation;
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
                obj = null;
            }
        }
    }
    void Update() {
        Pickedup();
        if (pickedup)
        {
            obj.transform.position = picksquare.transform.position;
            obj.transform.rotation = picksquare.transform.rotation;
        }
    }
}
