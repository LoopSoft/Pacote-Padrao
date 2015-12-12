using UnityEngine;

public class MSinTranslate : MovTemplate {

    public float min = -1, max = 1, normalize = .5f;
    private bool initSmooth = true;

    public override void play()
    {
        if (speed < .15f)
            speed += .001f * Time.deltaTime;

        float t = (Mathf.Sin((Time.time) * speed * Mathf.PI * 2f) + 1f) / 2f;

        //Evita que o movimento comece do máximo
        //Ex.: Quando o objeto está no meio da cena e o max e min estão no limite da tela
        if (initSmooth)
        {
            if (Mathf.Abs(t - normalize) <= 0.01f)
                initSmooth = false;
        }
        else
            transform.localPosition = (new Vector3(Mathf.Lerp(min, max, t), transform.position.y));
    }
}
