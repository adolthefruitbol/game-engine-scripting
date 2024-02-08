using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfCode : MonoBehaviour
{
    public int apples;
    public int bananas;

    [ContextMenu("Execute If Test")]
    

    void ExecuteIfTest()
    { 
        //Can be used to condense and clean up code
        bool has4ApplesOr2Bananas = apples == 4 || bananas == 2;
        int moneyOwed = (apples == 4 && bananas == 2) ? 200 : -200;
        
        int moneyOwed2 = 0;
        if (apples == 4 && bananas == 2)
        {
            moneyOwed = 200;
        }
        if (has4ApplesOr2Bananas)
        {
            Debug.Log(string.Format("We have {0} apples and {1} bananas", apples, bananas));
        }

        //either apples or bananas 
        if (apples == 4 || bananas == 2)
        {
            Debug.Log(string.Format("We have {0} apples and {1} bananas", apples, bananas));
        }
      //both apples and bananas
        if (apples == 4 && bananas == 2)
        {
            Debug.Log(string.Format("We have {0} apples and {1} bananas", apples, bananas));
        } 
      //If either apples or bananas is not 4/2 then if apples is 2 and bananas is less than or equal to 10
        else if(apples == 2 ||(apples == 4 && bananas > 0))
        {
            Debug.Log(string.Format("We have {0 apples and {1} bananas", apples, bananas));
        }
        else 
        {
            Debug.Log("we have no apples or bananas");
        }


        //Can be used to condense and clean up code
        if (apples == 4 && bananas == 2)
        {
            moneyOwed = 200; //nested
        }
        if (has4ApplesOr2Bananas) //nested
        {
            Debug.Log(string.Format("We have {0} apples and {1} bananas", apples, bananas));
        }

    }
}


