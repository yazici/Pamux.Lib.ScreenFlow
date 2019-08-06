using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    /*
    
        Background Content: Good graphics, animated scene, VFX and SFX, music, Mini Game
        SubMenus: panels...
        Geometric, simplistic, solid 
        Interactive & Response (mouse over events, etc)



        Splash

        Logo

        Easter Eggs

        Theater
        Help / Options
        Controls

        Pause/Resume
        High Scores
        About

    
     
    Play!
        New
        Continue
        Load Game
        Multiplayer
        Campaign
        Tutorial
    Customize
        Characters
        World/Level
        Difficulty

    Mods
    Options/Settings
    Credits
    Exit
        
        More Info (another game add as in Oxygen Not Included in Don't Starve)
        Now Available
        Forum
        Newsletter



    */

    private Transform mainMenu;
    private Transform aboutMenu;

    private float fadeTime;

    private Image[] mainMenuImages;
    private Image[] aboutMenuImages;

    IEnumerator FadeInOut(Transform inMenu, Image[] inImages, Transform outMenu, Image[] outImages, float duration)
    {
        inMenu.gameObject.SetActive(true);
        outMenu.gameObject.SetActive(true);
        fadeTime = 0f;
        while (fadeTime < duration)
        {
            fadeTime += Time.deltaTime;

            var inAlpha = Mathf.Lerp(0.0f, 1.0f, fadeTime / duration);
            var outAlpha = 1.0f - inAlpha;

            foreach (var image in inImages)
            {
                Color c = image.color;
                image.color = new Color(c.r, c.g, c.b, inAlpha);
            }

            foreach (var image in outImages)
            {
                Color c = image.color;
                image.color = new Color(c.r, c.g, c.b, outAlpha);
            }

            yield return true;
        }        
    }

    IEnumerator FadeInMainMenu()
    {
        yield return StartCoroutine(FadeInOut(mainMenu, mainMenuImages, aboutMenu, aboutMenuImages, 1.0f));
        yield return new WaitForSeconds(1.0f);

        aboutMenu.gameObject.SetActive(false);
    }
    IEnumerator FadeInAboutMenu()
    {
        yield return StartCoroutine(FadeInOut(aboutMenu, aboutMenuImages, mainMenu, mainMenuImages, 1.0f));
        yield return new WaitForSeconds(1.0f);

        mainMenu.gameObject.SetActive(false);
    }


    public void HandleStart()
    {
        
    }
    public void HandleAbout()
    {
        StartCoroutine(FadeInAboutMenu());
    }

    public void HandleBack()
    {
        StartCoroutine(FadeInMainMenu());
    }


    public void HandleExit()
    {
    }

    void Awake() {
        mainMenu = transform.Find("MainMenu");
        mainMenu.gameObject.SetActive(false);

        aboutMenu = transform.Find("AboutMenu");
        aboutMenu.gameObject.SetActive(false);

        mainMenuImages = mainMenu.GetComponentsInChildren<Image>();
        aboutMenuImages = aboutMenu.GetComponentsInChildren<Image>();

        foreach (var image in mainMenuImages)
        {
            Color c = image.color;
            image.color = new Color(c.r, c.g, c.b, 1.0f);
        }

        foreach (var image in aboutMenuImages)
        {
            Color c = image.color;
            image.color = new Color(c.r, c.g, c.b, 0.0f);
        }

        mainMenu.gameObject.SetActive(true);

        
    }
	
	
	void Update () {
		
	}
    
}
