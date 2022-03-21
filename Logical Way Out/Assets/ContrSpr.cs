using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContrSpr : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    private bool kn_morg = false;
    [SerializeField] Button Buttonspr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spr()
    {
        Panel.SetActive(!Panel.activeSelf);
        kn_morg = !kn_morg;
        if (Panel.activeSelf && kn_morg)
        {
            StartCoroutine(anim_kn());
        }
    }

    public IEnumerator anim_kn()
    {
        bool k = false;
        float i = 0.17f;
        while (kn_morg)
        {
            if (!k)
            {
                i += 0.003f;
                if (i >= 0.6)
                {
                    k = !k;
                }
            }
            else
            {
                i -= 0.003f;
                if (i <= 0.17)
                {
                    k = !k;
                }
            }
            Debug.Log(i);
            Buttonspr.GetComponent<Image>().color = new Color(Buttonspr.GetComponent<Image>().color.r, Buttonspr.GetComponent<Image>().color.g, Buttonspr.GetComponent<Image>().color.b, i);
            yield return null;
        }
    }
}
