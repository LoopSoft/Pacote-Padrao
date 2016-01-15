///<summary>
/// 17/09/2015, Parnamirim/RN
/// by Igor Felipe.
/// 
/// MenuSlider.cs - Este script atribui aos objetos adicionados a variavel "Menus" a possibilidade de movimenta-los horizontalmente,
/// aplicando um efeito de menu deslizante.
/// 
/// MODO DE USO: Atribuir este script a um objeto qualquer, e atribuir os objetos que serão os menus na lista "Menus", para que este script possa
/// fazer o controle da movimentação de cada objeto.
/// </summary>
using UnityEngine;
using System.Collections.Generic;

public class MenuSlider : MonoBehaviour {

    public List<GameObject> Menus;
    public float speedDeslocX = 10, retEffectDuration = 1, switchMenuSensibility = 10;
    public float DeslocWhenGreaterThanPercent = 30, DeslocPercentage;                       //DeslocPercentage não precisa ser configurado

    private float mouseX, fromPos = 0, startDragTime, mouseAux;
    private int focusedMenuIndex;

    /// <summary>
    /// Avança um menu a partir do index atual
    /// </summary>
    public void forwardMenu() {
        focusedMenuIndex++;
    }

    /// <summary>
    /// Volta um menu a partir do index atual
    /// </summary>
    public void backwardMenu() {
        focusedMenuIndex--;
    }

    /// <summary>
    /// Volta ao menu principal (onde o index é 0)
    /// </summary>
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
        else if (Input.GetMouseButtonUp(0))
        {
            switchfocusedMenu();
        }else
            normalizePos();

        //Limita os possíveis valores para "focusedMenuIndex" (Menu selecionado)
        focusedMenuIndex = (int)Mathf.Clamp(focusedMenuIndex, 0, Menus.Count-1);
        //Deslocamento atual do menu selecionado (focusedMenuIndex)
        DeslocPercentage = (Screen.width / 100) * Menus[focusedMenuIndex].GetComponent<RectTransform>().localPosition.x;
    }

    /// <summary>
    /// Obtém o toque (touch) e ativa a movimentação (deslize) dos menus
    /// </summary>
    void getInput()
    {
        //print(Input.GetTouch(0).position.x +"---"+ Input.GetTouch(0).deltaPosition.x);
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
            mouseX += Input.GetTouch(0).deltaPosition.x/(switchMenuSensibility);
            
        mouseAux += Input.GetTouch(0).deltaPosition.x /(switchMenuSensibility);
        fromPos = mouseX;
        startDragTime = Time.time;

        translateMenus();
        
    }

    /// <summary>
    /// Função responsável por movimentar os menus
    /// </summary>
    void translateMenus()
    {
        for (int i = 0; i < Menus.Count; ++i)
        {
            float offset = (Screen.width) * i;
            float desloc = offset + mouseX * speedDeslocX;
            Menus[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(desloc, 0);
        }
    }

    /// <summary>
    /// Função responsável pela troca dos menus, somente troca de valores e não movimento.
    /// detecta se o menu se deslocou mais de que a porcentagem determinada pela variável "switchWhenDividedBy"
    /// </summary>
    void switchfocusedMenu()
    {
        float desloc = Menus[focusedMenuIndex].GetComponent<RectTransform>().localPosition.x;

        if (desloc < -((Screen.width /100) * DeslocWhenGreaterThanPercent))
        {
            print("Aumentou");
            forwardMenu();
            mouseAux = 0;
        }
        else if (desloc > ((Screen.width / 100) * DeslocWhenGreaterThanPercent))
        {
            print("Diminuiu");
            backwardMenu();
            mouseAux = 0;
        }

        /*if (mouseAux > switchMenuSensibility)
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
        }*/
    }


    /// <summary>
    /// Função responsável pela estabilização/centralização dos menus. Ela quem dá o efeito deslizante
    /// </summary>
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
