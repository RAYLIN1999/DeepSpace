using System;
using System.Collections.Generic;

/// <summary>
/// The simple task in a story, with progress check, may contain not chronological sub tasks
/// </summary>
public class Mission
{
    /// <summary>
    /// The setup function that setup the scene or game state
    /// </summary>
    public Action setup;
    /// <summary>
    /// The finalize function that do clean job after a mission
    /// </summary>
    public Action finalize;
    /// <summary>
    /// The checkers that check the progress of each sub task
    /// </summary>
    public List<Action> subTaskCheck;
    /// <summary>
    /// The progress of each sub task
    /// </summary>
    public List<int> subTaskProgress;
    /// <summary>
    /// Indicate if a sub task is finished
    /// </summary>
    public List<bool> subTaskFinished;
    /// <summary>
    /// The description text of sub tasks
    /// </summary>
    public List<string> subTaskText;
    /// <summary>
    /// Test if this mission is completely finished
    /// </summary>
    public bool Finished
    {
        get
        {
            foreach (var item in subTaskFinished)
            {
                if (item != true)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

/// <summary>
/// The story may contain multiple chronological tasks, controls the dramatic elements
/// </summary>
public abstract class Story
{
    /// <summary>
    /// Internal make ID function
    /// </summary>
    /// <param name="_IsMain">Is this story a main story?</param>
    /// <param name="_ID">The ordinal number</param>
    /// <returns>The compiled ID</returns>
    static protected int MakeID(bool _IsMain, int _ID)
    {
        return _IsMain ? _ID : _ID << 16; //65535 is enough for this game
    }
    /// <summary>
    /// Set a callback function into combat system to capture combat events before the event is calculated
    /// </summary>
    /// <param name="_Callback">Callback Func: (Source, Target, Info) => true: object found, false: not found</param>
    static protected void SetPriorCombatTarget(Func<BasicCombatant, BasicCombatant, CombatMessenger, bool> _Callback)
    {
        CombatSystem.AddPriorFunc(_Callback);
    }
    /// <summary>
    /// Set a callback function into combat system to capture combat events after the event is calculated
    /// </summary>
    /// <param name="_Callback">Callback Func: (Source, Target, Info, CombatResult) => true: object found, false: not found</param>
    static protected void SetLaterCombatTarget(Func<BasicCombatant, BasicCombatant, CombatMessenger, CombatActionReturn, bool> _Callback)
    {
        CombatSystem.AddLaterFunc(_Callback);
    }
    /// <summary>
    /// Story Name
    /// </summary>
    abstract public string Name { get; }
    /// <summary>
    /// Story Id
    /// </summary>
    abstract public int StoryId { get; }
    /// <summary>
    /// Story Content (Text description)
    /// </summary>
    abstract public string Content { get; }
    /// <summary>
    /// List of missions in this story
    /// </summary>
    abstract public List<Mission> MissList { get; }
    /// <summary>
    /// The mission that is currentlt in progress
    /// </summary>
    public int CurrentMission { get; set; } = 0;
    /// <summary>
    /// To determine the next story
    /// </summary>
    abstract public Story NextStory { get; }

}