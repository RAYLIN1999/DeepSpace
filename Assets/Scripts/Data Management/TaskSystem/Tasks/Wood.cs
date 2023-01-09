
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class Wood : Story
{
    public override string Name => "Wood: the Kingdom";

    public override int StoryId => MakeID(true, 1);

    public override string Content => "Wood Quests";

    public Wood()
    {
        missList = new()
        {
            new Mission
            {
                setup = () => { TaskMenu.Instance.SetWoodProgress(6); },
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