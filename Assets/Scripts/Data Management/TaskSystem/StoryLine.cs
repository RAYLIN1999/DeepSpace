using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

/// <summary>
/// The story controller which holds the active instances of stories 
/// </summary>
public class StoryLine : MonoBehaviour
{
    static public StoryLine Instance = null;
    // quest heads
    private Story tutorial = new Tutorial();
    private Story firstWood = null;
    private Story firstFire = null;
    private Story firstMain = null;

    //states
    static private Story currentMain = null;
    static private Story currentFire = null;
    static private Story currentWood = null;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        TaskMenu.Instance.SetTutorialText(tutorial.Content);
        tutorial.MissList[tutorial.CurrentMission].setup();
        SetupToturialMission(tutorial.MissList[tutorial.CurrentMission]);
    }
    public void Restart()
    {
        currentMain = null;
        currentFire = null;
        currentWood = null;
        TaskMenu.Instance.Restart();
    }
    /// <summary>
    /// Test if a story is finished
    /// </summary>
    /// <param name="_Story">To be tested</param>
    /// <returns></returns>
    private bool CheckStoryFinished(Story _Story)
    {
        // check if the last mission finished in this story
        return _Story.MissList[_Story.MissList.Count - 1].Finished;
    }
    void SetupToturialMission(Mission _Miss)
    {
        _Miss.setup();

        string toturialDetailText = "";
        foreach (var item in _Miss.subTaskText)
        {
            toturialDetailText += item + "\n";
        }
        TaskMenu.Instance.SetTutorialTextDetail(toturialDetailText);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckStoryFinished(tutorial))
        {//continue toturial
            if (tutorial.MissList[tutorial.CurrentMission].Finished)
            {
                tutorial.MissList[tutorial.CurrentMission].finalize();
                tutorial.CurrentMission++;
                if (tutorial.CurrentMission < tutorial.MissList.Count)
                {
                    SetupToturialMission(tutorial.MissList[tutorial.CurrentMission]);
                }
            }
            else
            {
                foreach (var func in tutorial.MissList[tutorial.CurrentMission].subTaskCheck)
                {
                    func();
                }
            }
        }
        return; //TODO: write stories
        // check wood quests progress
        if (GameState.WoodAccessed)
        {
            if (currentWood == null)
            {
                currentWood = firstWood;
                currentWood.MissList[currentWood.CurrentMission].setup();
            }
            if (currentWood.MissList[currentWood.CurrentMission].Finished)
            {
                currentWood.MissList[currentWood.CurrentMission].finalize();
                currentWood.CurrentMission++;
                if (currentWood.CurrentMission < currentWood.MissList.Count)
                {
                    currentWood.MissList[currentWood.CurrentMission].setup();
                }
                else
                {
                    currentWood = currentWood.NextStory;
                    TaskMenu.Instance.SetWoodProgress(TaskMenu.Instance.currMaxWood + 1);
                }

            }
            else
            {
                foreach (var func in currentWood.MissList[currentWood.CurrentMission].subTaskCheck)
                {
                    func();
                }
            }
        }
        // check fire quests progress
        if (GameState.FireAccessed)
        {
            if (currentFire == null)
            {
                currentFire = firstFire;
                currentFire.MissList[currentFire.CurrentMission].setup();
            }
            if (currentFire.MissList[currentFire.CurrentMission].Finished)
            {
                currentFire.MissList[currentFire.CurrentMission].finalize();
                currentFire.CurrentMission++;
                if (currentFire.CurrentMission < currentFire.MissList.Count)
                {
                    currentFire.MissList[currentFire.CurrentMission].setup();
                }
                else
                {
                    currentFire = currentFire.NextStory;
                    TaskMenu.Instance.SetWoodProgress(TaskMenu.Instance.currMaxFire + 1);
                }

            }
            else
            {
                foreach (var func in currentFire.MissList[currentFire.CurrentMission].subTaskCheck)
                {
                    func();
                }
            }

        }
        // check main quests progress
        if (currentMain == null)
        {
            currentMain = firstMain;
            currentMain.MissList[currentMain.CurrentMission].setup();
        }
        if (currentMain.MissList[currentMain.CurrentMission].Finished)
        {
            currentMain.MissList[currentMain.CurrentMission].finalize();
            currentMain.CurrentMission++;
            if (currentMain.CurrentMission < currentMain.MissList.Count)
            {
                currentMain.MissList[currentMain.CurrentMission].setup();
            }
            else
            {
                currentMain = currentMain.NextStory;
                TaskMenu.Instance.SetWoodProgress(TaskMenu.Instance.currMaxMain + 1);
            }

        }
        else
        {
            foreach (var func in currentMain.MissList[currentMain.CurrentMission].subTaskCheck)
            {
                func();
            }
        }
    }
}
