using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    // Use this for initialization
    int removeAds = 0;

    public GameObject introductionMenu;


    void Start () {
        if (PlayerPrefs.GetInt("Introduction") != 1)
        {
            introductionMenu.SetActive(true);
        }

        removeAds = PlayerPrefs.GetInt("RemoveAds");
        Debug.Log("removeads: "+removeAds);
        if (Reload.gameOverCount > 2 && removeAds != 1)
        {
            GameObject.FindGameObjectWithTag("InterAds").GetComponent<InterAdsController>().ShowAds();
            Reload.gameOverCount = 0;
        }

        introductionMenu.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
        gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
        gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;

        removeAds = PlayerPrefs.GetInt("RemoveAds");

        if (removeAds == 1)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
    }

    public void RemoveAds()
    {
        Purchaser.Instance.BuyRemoveAds();
    }

    public void SkipIntroduction()
    {
        introductionMenu.SetActive(false);
        PlayerPrefs.SetInt("Introduction", 1);
    }
}
