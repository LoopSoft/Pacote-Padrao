using UnityEngine;
using System.Collections;
public class PontosEmMoedas : MonoBehaviour {

    public int _pontos = 0;
    public int _moedas = 0;

	void Start () { _moedas = Pontos_Em_Moedas(_pontos); }
	void Update () {}

    public int Pontos_Em_Moedas(int _pontos)
    {
        int _moedas = 0;
        for (int i = _pontos; i <= 0; i -= 5)
        {
            if (i < 5) break;
            else
            {
                print(_moedas);
                _moedas++;
                return _moedas;
            }
        }
        return _moedas;
    }
}
