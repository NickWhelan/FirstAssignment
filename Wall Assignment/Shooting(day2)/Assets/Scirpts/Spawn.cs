using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public Rigidbody player;
    public GameObject[] points;
	// Use this for initialization
	void Start () {
        int index = Random.Range(-1, points.Length);
        if (index< 0|| index > points.Length) { index = Random.Range(-1, points.Length); }
        Rigidbody newplayer = Instantiate(player,points[index].transform.position, points[index].transform.rotation) as Rigidbody;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
