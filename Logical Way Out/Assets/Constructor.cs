using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : MonoBehaviour
{
    [SerializeField] GameObject iznach_panel;
    [SerializeField] GameObject pref_comp;
    [SerializeField] GameObject pref_obuch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void vibor_razmera_karti(bool bolsh)
    {
        iznach_panel.SetActive(false);
        Destroy(FindObjectOfType<Camera>());
        if(bolsh)
        {
            Instantiate(pref_comp);
        }
        else
        {
            Instantiate(pref_obuch);
        }
    }
}
