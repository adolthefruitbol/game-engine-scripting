using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    [SerializeField]
    public int[] peg1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public int[] peg2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] peg3 = { 0, 0, 0, 0, 0, 0, 0, 0 };

    public int currentPeg = 1;

    [ContextMenu("Move Right")]
    void MoveRight()
    {
        //get lists we are working with
        int[] currentList = GetPeg(currentPeg);
        int[] targetList = GetPeg(currentPeg + 1);

        //check that target list is a real list
        if (targetList == null) return;

        //get the top number index from the current list
        int fromIndex = GetTopNumberIndex(currentList);
        //get the bottom most free index from the target list
        int toIndex = GetBottomNumberIndex(targetList);

        //check that we were able to find a free spot in the target list
        if(toIndex == -1) return;

        //Check that the number we want to move does not break our rules
        //for moving betweem pegs (no big on top or small)
        if (CanMoveIntoPeg(currentList[fromIndex], currentList) == false) return;

        MoveIntoPeg(fromIndex,toIndex,currentList,targetList);
    }

    void MoveLeft()
    {
        //get lists we are working with
        int[] currentList = GetPeg(currentPeg);
        int[] targetList = GetPeg(currentPeg + 1);

        //check that target list is a real list
        if (targetList == null) return;

        //get the top number index from the current list
        int fromIndex = GetTopNumberIndex(currentList);
        //get the bottom most free index from the target list
        int toIndex = GetBottomNumberIndex(targetList);

        //check that we were able to find a free spot in the target list
        if (toIndex == 1) return;

        //Check that the number we want to move does not break our rules
        //for moving betweem pegs (no big on top or small)
        if (CanMoveIntoPeg(currentList[fromIndex], currentList) == false) return;

        MoveIntoPeg(fromIndex, toIndex, currentList, targetList);
    }
    int GetTopNumberIndex(int[] peg)
    {
        for(int i = 0; i < peg.Length; i++)
        {
            if (peg[i] != 0) return i;
        }
        return -1;
    }

    int GetBottomNumberIndex(int[] peg)
    {
        for (int i = peg.Length - 1; i>= 0; i--)
        {
            if (peg[i] == 0) return i;
        }
        return -1;
    }

    bool CanMoveIntoPeg(int numberToMove, int[] peg)
    {
        int bottomIndex = GetBottomNumberIndex(peg);

        if (bottomIndex == peg.Length - 1 && peg[peg.Length - 1] == 0) return true;

        int bottomPlus1 = ++bottomIndex; 

        return bottomPlus1== 0;
    }

    void MoveIntoPeg(int fromIndex, int toIndex, int[] from, int[] to)
    {
        int numberToMove = from[fromIndex];
        from[fromIndex] = 0;
        to[fromIndex] = numberToMove;
    }
    int[] GetPeg(int peg)
    {
        if (peg == 1) return peg1;
        if (peg == 2) return peg2;
        if (peg == 3) return peg3;
        
        return null;
    }


}
