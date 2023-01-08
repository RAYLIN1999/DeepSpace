
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class Tutorial : Story
{
    public override string Name => "Tutorial: Startup";

    public override int StoryId => MakeID(true, 1);

    public override string Content => "This is a tutorial, press T for task details";

    public Tutorial()
    {
        missList = new()
        {
            new Mission
            {
                setup = () => { AITrigger = GameObject.Find("AITrigger"); },
                finalize = () => { },
                subTaskCheck = new()
                {
                    () => {
                        if(AITrigger.GetComponent<StoryTrigger>().IsTriggered && Input.GetKeyDown(KeyCode.F))
                            missList[0].subTaskFinished[0] = true;
                    },
                },
                subTaskProgress = null,
                subTaskFinished = new()
                {
                    false
                },
                subTaskText = new()
                {
                    "Talk with ship AI",
                },
            },
            new Mission
            {
                setup = () => { },
                finalize = () => { },
                subTaskCheck = new()
                {
                    () => {
                        if(Input.GetKeyDown(KeyCode.W))
                            missList[1].subTaskProgress[0] |= 0b0001;
                        if(Input.GetKeyDown(KeyCode.A))
                            missList[1].subTaskProgress[0] |= 0b0010;
                        if(Input.GetKeyDown(KeyCode.S))
                            missList[1].subTaskProgress[0] |= 0b0100;
                        if(Input.GetKeyDown(KeyCode.D))
                            missList[1].subTaskProgress[0] |= 0b1000;

                        if(missList[1].subTaskProgress[0]==0b1111)
                            missList[1].subTaskFinished[0] =true;
                    },
                    () => {
                        if(Input.GetKeyDown(KeyCode.Space))
                            missList[1].subTaskFinished[1] =true;
                    },
                },
                subTaskProgress = new()
                {
                    0b0000, 0
                },
                subTaskFinished = new()
                {
                    false, false
                },
                subTaskText = new()
                {
                    "Move around using WASD",
                    "Junmp using space",
                },
            },
            new Mission
            {
                setup = () => { OxTank= GameObject.Find("oxygen_tank_tutorial"); },
                finalize = () => {},
                subTaskCheck = new()
                {
                    () => {
                        if(OxTank.GetComponent<StoryTrigger>().IsTriggered && Input.GetKeyDown(KeyCode.F))
                        {
                            missList[2].subTaskFinished[0] = true;
                            missList[2].subTaskProgress[0] = GameState.ItemAmount[1];//TODO: ID
                        }
                    },
                    () => {
                        if(GameState.ItemAmount[1]<missList[2].subTaskProgress[0])
                            missList[2].subTaskFinished[1] = true; 
                    },
                },
               subTaskProgress = new()
                {
                    0
                },
                subTaskFinished = new()
                {
                    false, false
                },
                subTaskText = new()
                {
                    "Pick up the Oxygen tank",
                    "Use the oxygen tank in inventory",
                },
            },
            new Mission
            {
                setup = () => {
                    SetPriorCombatTarget((s,t,i)=>{
                        if(s == Player.Instance.GetComponent<BasicCombatant>())
                        {
                            missList[3].subTaskFinished[0] = true; return true;
                        }
                        return false;
                    });
                    SetLaterCombatTarget((s,t,i,r)=>{
                        if(s == Player.Instance.GetComponent<BasicCombatant>() && r.killed == true)
                        {
                            missList[3].subTaskFinished[1] = true; return true;
                        }
                        return false;
                    });
                },
                finalize = () => {},
                subTaskCheck = new()
                {
                    () => {
                        if(Input.GetKeyDown(KeyCode.R))
                            missList[3].subTaskFinished[2] = true;
                    },
                },
                subTaskProgress = new()
                {
                    0, 0, 0
                },
                subTaskFinished = new()
                {
                    false, false, false
                },
                subTaskText = new()
                {
                    "Use Left Button to shoot monsters",
                    "Kill 1 monster outside the ship",
                    "Use R to reload",
                },
            },
            new Mission
            {
                setup = () => { },
                finalize = () => {},
                subTaskCheck = new()
                {
                    () => {
                        if(AITrigger.GetComponent<StoryTrigger>().IsTriggered && Input.GetKeyDown(KeyCode.F))
                            missList[4].subTaskFinished[0] = true;
                    },
                },
                subTaskProgress = null,
                subTaskFinished = new()
                {
                    false
                },
                subTaskText = new()
                {
                   "Talk with ship AI again",
                },
            },
        };
    }

    private List<Mission> missList;
    public override List<Mission> MissList => missList;
    public override Story NextStory => null;// new Main1();

    // Related Game Objects
    GameObject AITrigger = null;
    GameObject OxTank = null;

}