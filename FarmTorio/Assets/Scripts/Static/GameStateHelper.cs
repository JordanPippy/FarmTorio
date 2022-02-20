using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStateHelper
{
    public static bool UIOpen = false;
    public static int inventorySpace = 24;

    public static Vector3Int minesTeleportLocation = new Vector3Int(-242, 96, 0);
    public static Vector3Int farmTeleportLocation = new Vector3Int(5, 0, 0);

    public enum ToolType
    {
        PICKAXE,
        HOE
    }
}