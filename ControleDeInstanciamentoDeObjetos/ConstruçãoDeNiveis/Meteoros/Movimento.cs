using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

    public float _speed = 5;
    public float _rotateForFram = 5;
	void Update () {
        gameObject.transform.position += new Vector3(transform.position.x, - (_speed / 2) * Time.deltaTime, 0);
        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, _rotateForFram * Time.deltaTime); 
	}
}
