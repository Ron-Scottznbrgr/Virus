using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleScreenManager : MonoBehaviour
{
    public Button btn_startButton, btn_exitButton, btn_playerSettings, btn_gameSettings;

    //public static TitleScreenManager instance;

    public Skin_Selector Loadoat;

    [Header("UI Panels")]

    
    [SerializeField] private GameObject pnl_MainMenu=null;
    
    [SerializeField] private GameObject pnl_HostOrJoinPanel = null;
    [SerializeField] private GameObject pnl_Host_Lobby = null;
    [SerializeField] private GameObject pnl_Join_Lobby = null;
    [SerializeField] private GameObject pnl_PlayerSettings = null;
    [SerializeField] private GameObject pnl_GameSettings = null;
    
    /* private GameObject pnl_MainMenu;

     private GameObject pnl_HostOrJoinPanel;
     private GameObject pnl_Host_Lobby;
     private GameObject pnl_Join_Lobby;
     private GameObject pnl_PlayerSettings;
     private GameObject pnl_GameSettings;*/

    // [SerializeField] private GameObject EnterIPAddressPanel;

    [Header("PlayerName UI")]
    [SerializeField] private TMP_InputField playerNameInputField = null;

    [Header("Enter IP UI")]
    [SerializeField] private TMP_InputField IpAddressField;

    

    private const string PlayerPrefsName = "";
    private const string PlayerPrefsFaceNum = "0";
    private const string PlayerPrefsSkinNum = "0";
    private const string PlayerPrefsPowerNum = "0";

    public int skin;
    public int face;
    public int power;
    public string poopname;



    private void Start()
    {
        ReturnToMainMenu();
        GetSavedLoadout();
        btn_startButton.onClick.AddListener(OpenGame);
        btn_exitButton.onClick.AddListener(ExitGame);
        btn_playerSettings.onClick.AddListener(OpenPlayerSettings);
        btn_gameSettings.onClick.AddListener(OpenGameSettings);

    }

    void OpenGame()
    {
        SceneManager.LoadScene("Backup_Scene");
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void OpenPlayerSettings()
        {
        pnl_MainMenu.SetActive(false);
        pnl_PlayerSettings.SetActive(true);
    }

    void OpenGameSettings()
    {

    }

    public void ReturnToMainMenu()
    {
        /*
         *  [SerializeField] private GameObject pnl_HostOrJoinPanel;
         *  [SerializeField] private GameObject pnl_Host_Lobby;
         *  [SerializeField] private GameObject pnl_Join_Lobby;
         *  [SerializeField] private GameObject pnl_PlayerSettings;
         *  [SerializeField] private GameObject pnl_GameSettings; 
        */
        
        pnl_MainMenu.SetActive(true);
        pnl_PlayerSettings.SetActive(false);
        pnl_GameSettings.SetActive(false);
        pnl_HostOrJoinPanel.SetActive(false);
        pnl_Host_Lobby.SetActive(false);
        pnl_Join_Lobby.SetActive(false);

        

    }

    void GetSavedLoadout()
    {
         if (PlayerPrefs.HasKey(PlayerPrefsName))
         {
            Debug.Log("NAME");
                playerNameInputField.text = PlayerPrefs.GetString(PlayerPrefsName);
            Loadoat.playerName.text = PlayerPrefs.GetString(PlayerPrefsName);
            poopname = PlayerPrefs.GetString(PlayerPrefsName);
        }


        if (PlayerPrefs.HasKey(PlayerPrefsFaceNum))
        {
            Debug.Log("FACE");
            Loadoat.faceNum = PlayerPrefs.GetInt(PlayerPrefsFaceNum);
            face = PlayerPrefs.GetInt(PlayerPrefsFaceNum);

        }

        if (PlayerPrefs.HasKey(PlayerPrefsSkinNum))
        {
            Debug.Log("SKIN");
            Loadoat.skinNum = PlayerPrefs.GetInt(PlayerPrefsSkinNum);
            skin = PlayerPrefs.GetInt(PlayerPrefsSkinNum);
            //playerNameInputField.text = PlayerPrefs.GetInt(PlayerPrefsSkinNum);
        }

        if (PlayerPrefs.HasKey(PlayerPrefsPowerNum))
        {
            Debug.Log("POWER");
            Loadoat.powerNum = PlayerPrefs.GetInt(PlayerPrefsPowerNum);
            power = PlayerPrefs.GetInt(PlayerPrefsPowerNum);
            // playerNameInputField.text = PlayerPrefs.GetInt(PlayerPrefsPowerNum);



        }
    }

    


    public void SavePlayerPrefs(int face, int skin, int power)
    {
        string playerName = null;
        if (!string.IsNullOrEmpty(playerNameInputField.text))
        {
            playerName = playerNameInputField.text;
            PlayerPrefs.SetString(PlayerPrefsName, playerName);
            PlayerPrefs.SetInt(PlayerPrefsFaceNum, face);
            PlayerPrefs.SetInt(PlayerPrefsSkinNum, skin);
            PlayerPrefs.SetInt(PlayerPrefsPowerNum, power);
            PlayerPrefs.Save();
            Debug.Log("Saved(?)");

            
            //PlayerNamePanel.SetActive(false);
            //pnl_HostOrJoinPanel.SetActive(true);
        }
    }

}
