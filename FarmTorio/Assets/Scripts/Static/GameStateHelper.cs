using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStateHelper
{
    public static bool UIOpen = false;
    public static int inventorySpace = 24;

    public enum ToolType
    {
        PICKAXE,
        HOE
    }
}