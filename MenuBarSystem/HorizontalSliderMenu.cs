///<summary>
/// Este script movimento o objeto de canvas da posição inicial até a posição 0
/// </summary>
using UnityEngine;
using System.Collections;

public class HorizontalSliderMenu : MonoBehaviour {

    public GameObject Parent;

    public float initPosX;
    public float smoothTime = 0.3F;
    private float xVelocity = 0.0F;
    private bool showMenu = false;

    void Start()
    {
        //centerX = transform.localPosition.x;
    }

    void Update()
    {
        if (showMenu)
        {
            CancelInvoke("Deactive");
            show();
        }
        else
            hide();
    }

    public void setShowHideMenu(bool value)
    {
        showMenu = value;
    }

    void show()
    {
        float newPosition = Mathf.SmoothDamp(transform.localPosition.x, 0, ref xVelocity, smoothTime);
        transform.localPosition = new Vector3(newPosition, transform.localPosition.y, transform.localPosition.z);
    }

    void hide()
    {
        float newPosition = Mathf.SmoothDamp(transform.localPosition.x, initPosX, ref xVelocity, smoothTime);
        transform.localPosition = new Vector3(newPosition, transform.localPosition.y, transform.localPosition.z);
        Invoke("Deactive", 2);
    }

    void Deactive()
    {
        Parent.SetActive(false);
    }
}
