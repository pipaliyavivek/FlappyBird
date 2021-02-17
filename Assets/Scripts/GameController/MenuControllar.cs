using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllar : MonoBehaviour
{
    public static MenuControllar instance;
    [SerializeField]
    private GameObject[] Birds;

    private bool IsGreenBirdUnlockd, IsRedBirdUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        Birds[GameControllar.instance.GetSelectedBird()].SetActive (true) ;
        CheckBiredAreUnlocked();
    }
    private void Awake()
    {
        MakeInstance();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckBiredAreUnlocked()
    {
        if(GameControllar.instance.IsRedBirdUnlocked ()==1)
        {
            IsRedBirdUnlocked = true;   
        }
        if (GameControllar.instance.IsGreenBirdUnlocked ()  == 1)
        {
            IsGreenBirdUnlockd = true;
        }
    }
    void MakeInstance()
    {
        if(instance ==null )
        {
            instance = this;
        }
    }
    public void ChangeBired()
    {
        if (GameControllar.instance.GetSelectedBird() == 0)
        {  
            if (IsGreenBirdUnlockd)
            {
                Birds[0].SetActive(false);
                GameControllar.instance.SetSelectedBird(1);

                Birds[GameControllar.instance.GetSelectedBird()].SetActive(true);
            }
        }
        else if (GameControllar.instance.GetSelectedBird() == 1)
        {
            if (IsRedBirdUnlocked)
            {
                Birds[1].SetActive(false);
                GameControllar.instance.SetSelectedBird(2);

                Birds[GameControllar.instance.GetSelectedBird()].SetActive(true);
            }
            else
            {
                Birds[1].SetActive(false);
                GameControllar.instance.SetSelectedBird(0);
                Birds[GameControllar.instance.GetSelectedBird()].SetActive(true);
            }
        }
        else if(GameControllar .instance .GetSelectedBird ()==2)
        {
            Birds[2].SetActive(false);
            GameControllar.instance.SetSelectedBird(0);
            Birds[GameControllar.instance.GetSelectedBird()].SetActive(true);
        }
        }
       public void PlayGame()
       {
        SceneFader.instance.FadeIn("FlappyBird");
       }
    }

