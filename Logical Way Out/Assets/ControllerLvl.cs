using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ControllerLvl : MonoBehaviour
{
    [SerializeField] ContLvlUI endlvl;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        KOLYA Kolya = collision.GetComponent<KOLYA>();
        for (int i = 0; i < kn.perem.Length; i++)
        {
            kn.perem[i] = false;
        }
        StartCoroutine(KRASIVOENDLVL(Kolya));
    }
    private IEnumerator KRASIVOENDLVL(KOLYA Kolya)
    {
        for (float i = 1; i > 0; i -= 0.01f)
        {
            Kolya.Poshel(i);
            yield return null;
        }
        int num = 0;
        string k = SceneManager.GetActiveScene().name;
        if (k[k.Length - 1] != '8')
        {
            num = Convert.ToInt32(k[k.Length - 1].ToString()) + 1;
            Debug.Log(num);
        }
        k = k.Remove(k.Length - 1);
        k += num + "_dostup";
        Debug.Log(k);
        PlayerPrefs.SetInt(k,1);
        PlayerPrefs.Save();
        endlvl.endlvl();
        yield return null;
        
    }
}
