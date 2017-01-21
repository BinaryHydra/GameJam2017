using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject Play;
    public GameObject Score;
    public GameObject Exit;
    public GameObject Settings;
    public GameObject SettingsBack;
    public GameObject ScoreBack;
    public GameObject MegaLondon;
    public GameObject VeryBigChameleon;
    public GameObject MissTentacles;
    public GameObject PlayBack;



    public void PlayMygtukas()
    {
        Play.SetActive(false);
        Score.SetActive(false);
        Exit.SetActive(false);
        Settings.SetActive(false);
        MegaLondon.SetActive(true);
        VeryBigChameleon.SetActive(true);
        MissTentacles.SetActive(true);
        PlayBack.SetActive(true);
    }

    public void PlayBackMygtukas()
    {
        Play.SetActive(true);
        Score.SetActive(true);
        Exit.SetActive(true);
        Settings.SetActive(true);
        MegaLondon.SetActive(false);
        VeryBigChameleon.SetActive(false);
        MissTentacles.SetActive(false);
        PlayBack.SetActive(false);
    }

    public void MegaLondonMygtukas()
    {
        SceneManager.LoadScene("sc_game");
    }

    public void VeryBigChameleonMygtukas()
    {
        SceneManager.LoadScene("sc_game");
    }

    public void MissTentaclesMygtukas()
    {
        SceneManager.LoadScene("sc_game");
    }

    public void ExitMygtukas()
    {
        Application.Quit();
    }

    public void ScoreMygtukas()
    {
        Play.SetActive(false);
        Score.SetActive(false);
        Exit.SetActive(false);
        Settings.SetActive(false);
        ScoreBack.SetActive(true);
    }

    public void SettingsMygtukas()
    {
        Play.SetActive(false);
        Score.SetActive(false);
        Exit.SetActive(false);
        Settings.SetActive(false);
        SettingsBack.SetActive(true);
    }

    public void SettingsBackMygtukas()
    {
        Play.SetActive(true);
        Score.SetActive(true);
        Exit.SetActive(true);
        SettingsBack.SetActive(false);
        Settings.SetActive(true);
    }

    public void ScoreBackMygtukas()
    {
        Play.SetActive(true);
        Score.SetActive(true);
        Exit.SetActive(true);
        ScoreBack.SetActive(false);
        Settings.SetActive(true);
    }

}
