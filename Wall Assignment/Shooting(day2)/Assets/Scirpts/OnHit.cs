using UnityEngine;
using System.Collections;

public class OnHit : MonoBehaviour {
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Box(Clone)"|| col.gameObject.name == "Sphere(Clone)")
            Destroy(this.gameObject, 1);
        else if (col.gameObject == true)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Destroy(this.gameObject, 10f);
        }
    }
}
