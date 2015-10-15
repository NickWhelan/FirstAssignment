using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public float speed =10;
	public Rigidbody projectile, projectile2;
    public GameObject gun;
	// Use this for initialization
	void Start () {
        //tp.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiateProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody instantiateProjectile = Instantiate(projectile2, transform.position, transform.rotation) as Rigidbody;
            instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
        }

    }
}