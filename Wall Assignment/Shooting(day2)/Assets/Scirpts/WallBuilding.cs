using UnityEngine;
using System.Collections;

public class WallBuilding : MonoBehaviour {
	public GameObject pos;
	public Rigidbody box1;
    public Vector3 sizeOfBoxCube;
	// Use this for initialization
	void Start () {
		Vector3 start = new Vector3();
		start.x = (pos.transform.position.x);
		start.y = (pos.transform.position.y);
		start.z = (pos.transform.position.z);
		for (int i=0; i < sizeOfBoxCube.z; i++) {
			for (int j=0; j < sizeOfBoxCube.y; j++) {
				for (int k=0; k < sizeOfBoxCube.x; k++) {
					Rigidbody cube = Instantiate(box1,start,transform.rotation) as  Rigidbody;
					start.x+= 1.5f;
				}
				start.x= pos.transform.position.x;
				start.y += 1.5f;
			}
			start.x= pos.transform.position.x;
			start.y = pos.transform.position.y;
			start.z += 1.5f;
		}
	}

}
