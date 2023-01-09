
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class Fire : Story
{
    public override string Name => "Fire: the Kingdom";

    public override int StoryId => MakeID(true, 3);

    public override string Content => "Fire Quests";

    public Fire()
    {
        missList = new()
        {
            new Mission
            {
                setup = () => { TaskMenu.Instance.SetFireProgress(5); },
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