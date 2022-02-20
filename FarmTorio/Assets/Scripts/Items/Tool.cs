using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tool : Item
{

    private GameStateHelper.ToolType toolType;
    public Tool() : base()
    {

    }
    public Tool(Sprite sprite, int id, string name, GameStateHelper.ToolType toolType) : base(sprite, id, name)
    {
        this.toolType = toolType;
    }

    public override void Use()
    {
        switch (toolType)
        {
            case GameStateHelper.ToolType.HOE:
                UseHoe();
                break;
            case GameStateHelper.ToolType.PICKAXE:
                UsePickaxe();
                break;
            default:
                Debug.Log("Invalid Tool?");
                break;
        }
    }

    private void UseHoe()
    {
        Debug.Log("Use Hoe method");
    }

    private void UsePickaxe()
    {
        Debug.Log("Use Pickaxe method");
    }
}
