///<summary>
/// 17/09/2015, Parnamirim/RN
/// by Igor Felipe.
/// 
/// MenuSlider.cs - Este script atribui aos objetos adicionados a variavel "Menus" a possibilidade de movimenta-los horizontalmente,
/// aplicando um efeito de menu deslizante.
/// 
/// MODO DE USO: Atribuir este script a um objeto qualquer, e também os objetos que serão os menus, para que este script possa
/// fazer o controle da movimentação de cada objeto.
/// </summary>
using UnityEngine;
using System.Collections.Generic;

public class MenuSlider : MonoBehaviour {

    public List<GameObject> Menus;
    public float speedDeslocX = 10, retEffectDuration = 1, switchMenuSensibility = 10, mouseAux;

    private float mouseX, fromPos = 0, startDragTime, focusedMenuIndex;

    public void forwardMenu() {
        focusedMenuIndex++;
    }
    public void backwardMenu() {
        focusedMenuIndex--;
    }
    public void homeMenu()
    {
        focusedMenuIndex = 0;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
            getInput();
        else// if (Input.GetMouseButtonUp(0))
            normalizePos();

        focusedMenuIndex = Mathf.Clamp(focusedMenuIndex, 0, Menus.Count-1);
	}

    void getInput()
    {
        //print(Input.GetTouch(0).position.x +"---"+ Input.GetTouch(0).deltaPosition.x);
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
            mouseX += Input.GetTouch(0).deltaPosition.x/switchMenuSensibility;
            
        mouseAux += Input.GetTouch(0).deltaPosition.x / switchMenuSensibility;
        fromPos = mouseX;
        startDragTime = Time.time;

        translateMenus();
        switchfocusedMenu();
    }

    void translateMenus()
    {
        for (int i = 0; i < Menus.Count; ++i)
        {
            float offset = (Screen.width) * i;
            float desloc = offset + mouseX * speedDeslocX;
            Menus[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(desloc, 0);// (desloc, Menus[i].transform.position.y);
        }
    }

    void switchfocusedMenu()
    {
        if (mouseAux > switchMenuSensibility)
        {
            print("Diminuiu");
            backwardMenu();
            mouseAux = 0;
        }
        else if (mouseAux < -switchMenuSensibility)
        {
            print("Aumentou");
            forwardMenu();
            mouseAux = 0;
        }
    }

    void normalizePos()
    {
        float t = (Time.time - startDragTime) / retEffectDuration;
        //0.76562
        //Screen.width/(10+Menus.Count)*testePos*
        mouseX = Mathf.SmoothStep(fromPos, -(Screen.width / 10f) * focusedMenuIndex, t);
        mouseAux = 0;

        translateMenus();
    }
}
