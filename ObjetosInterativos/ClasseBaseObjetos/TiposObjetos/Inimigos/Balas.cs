using UnityEngine;
using System.Collections;

public class Balas : BaseInimigos {

	public string _tagBalaInimigo = "BulletDoInimigo";

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == this._tagBalaPersonagem && gameObject.tag == _tagBalaInimigo){
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}
}
