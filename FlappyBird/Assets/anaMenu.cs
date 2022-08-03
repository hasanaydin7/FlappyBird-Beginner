using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class anaMenu : MonoBehaviour
{
    public Text puanText;
    public Text puan;
    void Start()
    {
        int enYuksekPuan = PlayerPrefs.GetInt("enYuksekPuanKaydi");
        int puanGelen = PlayerPrefs.GetInt("puanKaydi");

        puanText.text = "En Yuksek Puan = " + enYuksekPuan;
        puan.text = "Puan = " + puanGelen;
    }

   
    void Update()
    {
        
    }
    public void oyunaGit()
    {
        SceneManager.LoadScene("basla");
    }
    public void oyundanCik()
    {
        Application.Quit();
    }
}
