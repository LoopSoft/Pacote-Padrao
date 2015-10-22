///
/// - AtivaDesativaObjetos -
/// 
/// Controla se um objeto ta ativado ou desativa.
/// OBS.: o objeto(_object) deve esta inicialmente desativado.
using UnityEngine;
public class AtivaDesativaObjetos : MonoBehaviour {

    public GameObject _object;
    public bool _ativado = false;
    int cont = 1;

    public void ControlsActivation()
    {
        /// Init caso objeto seja inicialmente desativado
        if(cont == 1 && _ativado == false)
        {
            ++cont;
            _object.SetActive(true);
        }
        else if (cont == 2 && _ativado == false)
        {
            cont = 1;
            _object.SetActive(false);
        }
        /// End
        /// 
        /// Init caso objeto seja inicialmente ativado
        if(cont == 1 && _ativado == true)
        {
            ++cont;
            _object.SetActive(false);
        }
        else if (cont == 2 && _ativado == true)
        {
            cont = 1;
            _object.SetActive(true);
        }
        ///end
    }
}
