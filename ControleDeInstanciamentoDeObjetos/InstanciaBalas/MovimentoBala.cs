using UnityEngine;
using System.Collections;

public class MovimentoBala : MonoBehaviour {

    public float speed = 0.5f;
	void Update () {
        transform.position =new Vector3(transform.position.x, transform.position.y + speed*Time.deltaTime, 0);
	}
}
