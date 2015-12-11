///<summary>
/// Este script limita a posição de um objeto pela distancia do centro até ele (dá um efeito de limite 
/// redondo - como um joystick)
/// </summary>
using UnityEngine;
using System.Collections;

public class ObjMoveLimit : MonoBehaviour {



    public bool isRadial;
    public GameObject Parent;
    public float maxDist = 12;
    private Vector3 offset;

	// Update is called once per frame
	void Update () { 

        if(isRadial)
            ClampPositionToCircle(Parent.transform.position, maxDist);
	}
    
    public void ClampPositionToCircle(Vector3 center, float radius)
    {
        // Calculate the offset vector from the center of the circle to our position
        offset = transform.position - center;
        // Calculate the linear distance of this offset vector
        float distance = offset.magnitude;
        if (radius < distance)
        {
            // If the distance is more than our radius we need to clamp
            // Calculate the direction to our position
            Vector3 direction = offset / distance;
            // Calculate our new position using the direction to our old position and our radius
            transform.position = center + direction * radius;
        }
    }
}
