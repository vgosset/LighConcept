using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGeneration : MonoBehaviour
{
    public static MapGeneration Instance;

    [SerializeField] private List<GameObject> levelLst;

    [SerializeField] private GameObject CanvasMenu;
    [SerializeField] private GameObject CanvasGameplay;

    [SerializeField] private Text levelTxtMenu;
    [SerializeField] private Text levelTxt;
    
    private int lvlID = 0;

    private GameObject currentLvl;

    private void Awake()
    {
        Instance = this;
    }
    public void SpawnRandomLevel()
    {
        if (currentLvl)
            Destroy(currentLvl);
    
        int rdn = Random.Range(0, levelLst.Count);

        currentLvl = Instantiate(levelLst[rdn]);
        levelTxt.text = (rdn + 1).ToString();
    }
    public void SpawnLevel()
    {
        if (currentLvl)
            Destroy(currentLvl);
            
        currentLvl = Instantiate(levelLst[lvlID]);
        levelTxt.text = (lvlID + 1).ToString();
    }
    public void SetNextLevel()
    {
        lvlID = Mathf.Clamp(lvlID + 1, 0, levelLst.Count - 1);
        Debug.Log(lvlID);
        levelTxtMenu.text = (lvlID + 1).ToString();
    }
    public void SetPreviousLevel()
    {
        lvlID = Mathf.Clamp(lvlID - 1, 0, levelLst.Count - 1);
        Debug.Log(lvlID);
        levelTxtMenu.text = (lvlID + 1).ToString();
    }
    public void DelayedDeath()
    {
        CanvasMenu.SetActive(true);
        CanvasGameplay.SetActive(false);
        Destroy(currentLvl);
    }
    public void NextLevel()
    {
       SetNextLevel();
       SpawnLevel();
    }
}
