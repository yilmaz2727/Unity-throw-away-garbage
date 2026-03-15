using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MaýnMenupanel;
    public GameObject Settingspanel;
    public GameObject LoginPanel;
    [Header("LoginPanel")]  
    public GameObject boy_btn;
    private Image boy_btnImage;
    public Sprite[] boy_sprites;
    public GameObject girl_btn;
    private Image girl_btnImage;
    public Sprite[] girl_sprites;
    public TMP_InputField[] LoginTexts;

    public void Awake()
    {
        boy_btnImage=boy_btn.GetComponent<Image>();
        girl_btnImage =girl_btn.GetComponent<Image>();  
        LoginPanel.SetActive(true); 
        MaýnMenupanel.SetActive(false);
        Settingspanel.SetActive(false); 
    }

    //LoginPanel Buttons
    public void ContinueBtn()
    {
        LoginPanel.SetActive(false);
        MaýnMenupanel.SetActive(true);
    }
    public void BoyBtn()
    {  
        if( boy_btnImage.sprite == boy_sprites[0])
        {
           boy_btnImage.sprite =boy_sprites[1];
           girl_btnImage.sprite =girl_sprites[0];
        }
      
    }
    public void GirlBtn()
    {
        if (girl_btnImage.sprite == girl_sprites[0])
        {
            girl_btnImage.sprite = girl_sprites[1];
            boy_btnImage.sprite = boy_sprites[0];   
        }

       
    }

    //MaýnMenuPanel Buttons
    public void StartGameBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void SettingBtn()
    {
        LoginPanel.SetActive(false);
        MaýnMenupanel.SetActive(false);
        Settingspanel.SetActive(true);  
    }
    public void ExitBtn()
    {
        ResetLoginPanel();
        LoginPanel.SetActive(true);
        MaýnMenupanel.SetActive(false);
    }
    private void ResetLoginPanel()
    {
        foreach (var text in LoginTexts)
        {
            text.text = " ";
            
        }
        boy_btnImage.sprite = boy_sprites[0];
        girl_btnImage.sprite = girl_sprites[0];
    }
    //SettingsPanel Buttons 
    public void LogoutBtn()
    {
        MaýnMenupanel.SetActive(true);
        Settingspanel.SetActive(false);
    }
}
