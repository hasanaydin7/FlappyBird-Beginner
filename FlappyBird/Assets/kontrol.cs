using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kontrol : MonoBehaviour
{
    public Sprite []kusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kusAnimasyonZaman = 0;

    Rigidbody2D fizik;

    int puan = 0;

    public Text puanText;

    bool oyunBitti = true;

    oyunKontrol oyunKontrol;

    AudioSource []sesler;

    int enYuksekPuan = 0;

    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<oyunKontrol>();
        sesler=GetComponents<AudioSource>();
        enYuksekPuan = PlayerPrefs.GetInt("enYuksekPuanKaydi");
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && oyunBitti)
        {
            fizik.velocity = new Vector2(0,0);
            fizik.AddForce(new Vector2(0,200));
            sesler[0].Play();
            
        }
        if(fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        Animasyon();
    }
    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.2f)
        {
            kusAnimasyonZaman = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = kusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == kusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = kusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="puan")
        {
            puan++;
            puanText.text = "puan =" + puan;
            sesler[1].Play();
            
        }
        if(col.gameObject.tag=="engel")
        {
            oyunBitti = false;
            sesler[2].Play(); 
            oyunKontrol.oyunBitti();
            GetComponent<CircleCollider2D>().enabled = false;

            if(puan>enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("enYuksekPuanKaydi", enYuksekPuan);
            }
            Invoke("anaMenuyeDon", 2);
        }
    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puanKaydi",puan);
        SceneManager.LoadScene("anaMenu");
    }
}
