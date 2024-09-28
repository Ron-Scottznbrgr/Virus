using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Skin_Selector : MonoBehaviour
{

    public Button faceUp, faceDown,skinUp, skinDown, powerUp, powerDown, BackToMainMenu;
    public TMP_Text faceText, skinText, powerText;
    public TMP_InputField playerName;
    public int faceNum, skinNum, powerNum;

    public TitleScreenManager TSM;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //if playerprefs, load, if not, 0

        faceUp.onClick.AddListener(Increase_Face);
        faceDown.onClick.AddListener(Decrease_Face);
        skinUp.onClick.AddListener(Increase_Skin);
        skinDown.onClick.AddListener(Decrease_Skin);
        powerUp.onClick.AddListener(Increase_Power);
        powerDown.onClick.AddListener(Decrease_Power);

        BackToMainMenu.onClick.AddListener(ReturnToMain);

        playerName.onEndEdit.AddListener(delegate{Input_Name(playerName);});

        //faceNum = 0;
        //skinNum = 0;
        //powerNum = 0;

        faceText.text = faceNum.ToString();
        skinText.text = skinNum.ToString();
        powerText.text = powerNum.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        faceText.text = faceNum.ToString();
        skinText.text = skinNum.ToString();
        powerText.text = powerNum.ToString();
    }

    public void Increase_Face()
    {
        faceNum += 1;
    }

    public void Decrease_Face()
    {
        faceNum -= 1;
    }

    public void Increase_Skin()
    {
        skinNum += 1;
    }

    public void Decrease_Skin()
    {
        skinNum -= 1;
    }

    public void Increase_Power()
    {
        powerNum += 1;
    }

    public void Decrease_Power()
    {
        powerNum -= 1;
        
    }

    public void ReturnToMain()
    {

        TSM.SavePlayerPrefs(faceNum, skinNum, powerNum);
        TSM.ReturnToMainMenu();
    }

    public void Input_Name(TMP_InputField input)
    {
       // Debug.Log("Fired on Exit");
        Debug.Log("Text that was inputted: "+input.text);
        TSM.SavePlayerPrefs(faceNum,skinNum,powerNum);
        //faceText.text = input.text;
    }



}
