
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class Main1 : Story
{
    public override string Name => "Main: Fix Ship";

    public override int StoryId => MakeID(true, 2);

    public override string Content => "Main Quests";

    public Main1()
    {
        missList = new()
        {
            new Mission
            {
                setup = () => { TaskMenu.Instance.SetMainProgress(7); },
                finalize = () => { },
                subTaskCheck = new()
                {
                },
                subTaskProgress = null,
                subTaskFinished = new()
                {
                },
                subTaskText = new()
                {
                },
            }
        };
    }

    private List<Mission> missList;
    public override List<Mission> MissList => missList;
    public override Story NextStory => null;// new Main1();


}