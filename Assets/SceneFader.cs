using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadeCanvas;

    [SerializeField]
    private Animator fadeanim;

    void Start()
    {
    }
    void Awake()
    {
        MakeSingleton();
    }
    
    void Update()
    {
        
    }
    void MakeSingleton()
    {
        if(instance!= null )
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void FadeOut()
    {
        StartCoroutine (FadeOutAnimation());
    }
    public void FadeIn(string levelname)
    {
        StartCoroutine(FadeInAnimation(levelname));
    }

    IEnumerator FadeInAnimation(string  levelName)
    {
        fadeCanvas.SetActive(true);
        fadeanim.Play("FadeIn");
        Debug.Log("FadeIn");

        yield return StartCoroutine(MyCorutine.WaitForRealSeconds(.7f));
        Application.LoadLevel(levelName);
        FadeOut(); 
    }
    IEnumerator FadeOutAnimation()
    {
        Debug.Log("FadeOut");
        fadeanim.Play("FadeOut");
        yield return StartCoroutine(MyCorutine.WaitForRealSeconds(1f)); 
        fadeCanvas.SetActive(false);
    }
}
