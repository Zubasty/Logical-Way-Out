using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOLYA : MonoBehaviour
{
    private Rigidbody2D dviz;
    private SpriteRenderer Imag;
    [SerializeField] private Camera Cam;
    [SerializeField] private Camera Karta;
    private bool flag_karta = false;
    [SerializeField] public Per Controller_per;
    private Animator anim;
    private Collider2D hitCollider;
    bool end = false;
    private bool dvizh_razrch = true;
    private void Vkl_Karta()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cam.enabled = !Cam.enabled;
            Karta.enabled = !Karta.enabled;
            flag_karta = !flag_karta;
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        dviz = GetComponent<Rigidbody2D>();
        Imag = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        for (int i = 0; i<kn.perem.Length;i++)
        {
            kn.perem[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!end)
        {
            if(dvizh_razrch) // фиксим баг тЕмУрОм обнаруженный
                dvizhenie();
            Otkr_dver();
            Vkl_Karta();
        }
    }
    private void Otkr_dver()
    {
        if (Input.GetKeyDown(KeyCode.F) && kn.numb_p == -1 && !kn.proigr_anim)
        {
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(4f, 1f), 0f);
            foreach (Collider2D hitCollidera in hitColliders)
            {
                if (hitCollidera.name == "Кнопка")
                {
                    hitCollider = hitCollidera;
                    kn.proigr_anim = true;
                    Debug.Log("Коля зигует");
                    anim.SetTrigger("кн");
                }
            }
        }
    }
    public void activate_but()
    {
        Debug.Log("1) Коля нашел кнопку");
        hitCollider.SendMessage("Soobshay_koresham", SendMessageOptions.DontRequireReceiver); // 1)Коля пытается нажать кнопку
        hitCollider = null;
    }
    public void Poshel(float i)
    {
        end = true;
        dviz.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(i * 5, i * 5, -5);
        transform.Rotate(transform.rotation.x + Random.Range(-45, 45), transform.rotation.y + Random.Range(-45, 45), transform.rotation.z + Random.Range(-45, 45));
    }

    public void Nlz_dvizh()
    {
        dvizh_razrch = !dvizh_razrch;
    }
    private void dvizhenie()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 napr = new Vector2();
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                napr.y = 1;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                napr.y = -1;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                napr.x = 1;
                Imag.flipX = false;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                napr.x = -1;
                Imag.flipX = true;
            }
            dviz.velocity = napr;
            dviz.velocity = dviz.velocity.normalized * 12;
            Cam.transform.Translate(transform.position.x - Cam.transform.position.x, transform.position.y - Cam.transform.position.y, 0);
            anim.SetBool("Двигается", true);
        }
        else
        {
            dviz.velocity = new Vector2(0, 0);
            anim.SetBool("Двигается", false);
        }
    }
}
