using UnityEngine;
using System.Collections;
using FlipCube;
using uFrame.Kernel;

public class ShowGeneralMenuDispatcher : uFrameComponent{

    public void ShowMainMenu()
    {
        this.Publish(new ShowGeneralMenu()
        {
            State = GeneralGameUIState.MainMenu
        });
    }

    public void ShowLeaderBoard()
    {
        this.Publish(new ShowGeneralMenu()
        {
            State = GeneralGameUIState.LeaderBoard
        });
    }

    public void ShowLevelSelection()
    {
        this.Publish(new ShowGeneralMenu()
        {
            State = GeneralGameUIState.LevelSelection
        });
    }




}
