using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void OpenLink()
    {
        Application.ExternalEval("window.open('https://www.ccma.cat/324/que-fan-els-governs-polemica-despres-que-un-youtuber-ha-construit-100-pous-a-lafrica/noticia/3259396/','_blank')");
    }
}

