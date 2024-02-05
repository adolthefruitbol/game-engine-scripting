using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    //TODO: Create a TextMeshProUGUI variable here and assign it in the inspector
    public TextMeshProUGUI displayText;


    //TODO: Create a temporary float variable here called prevInput so we can store the previous input value
    //      when performaing calculations
    private float prevInput = 0f;

    //TODO: Create a bool variable called clearPrevInput here so we can flip it to true/false if we should clear the prior input
    //      when typing in values. Example, if we type in the value 402 and then press the + button, the next value I enter
    //      should replace the 402 I previously entered
    private bool clearPrevInput = false;

    //TODO: Leave this alone
    private EquationType equationType;

    private void Start()
    {
        Clear();
    }

    public void AddInput(string input)
    {
        //TODO: Check the clearPrevInput variable you created
        if (clearPrevInput)
        {
            //      and if true then set the current value of the text label to be string.Empty
            displayText.text = string.Empty;

            //      and set the clearPrevInput value to false
            clearPrevInput = false;
        }

        //TODO: Add the input passed into the AddInput function to the current value of the label
        //      Hint. You can perform the + operations on string data to combine them
        displayText.text += input;



    }

    public void SetEquationAsAdd()
    {
        //TODO: Store the current input value on the text label into the float variable you created.
        //      Hint. You will need to google float.Parse() and pass in the string value of the label.
        prevInput = float.Parse(displayText.text);
        //TODO: Set the bool you made to true so that the next number that gets typed in clears the calculator display.
        clearPrevInput = true;
        equationType = EquationType.ADD;
    }

    //TODO: Create a SetEquationAsSubtract function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.SUBTRACT
    public void SetEquationAsSubtract()
    {
        prevInput = float.Parse(displayText.text);
        clearPrevInput = true;
        equationType = EquationType.SUBTRACT;
    }

    //TODO: Create a SetEquationAsMultiply function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.Multiply
    public void SetEquationAsMultiply()
    {
        prevInput = float.Parse(displayText.text);
        clearPrevInput = true;
        equationType = EquationType.MULTIPLY;
    }    

    //TODO: Create a SetEquationAsDivide function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.DIVIDE
    public void SetEquationAsDivide()
    {
        prevInput = float.Parse(displayText.text);
        clearPrevInput= true;
        equationType = EquationType.DIVIDE;
    }    
    public void Add()
    {
        //TODO: Calculate the sum of the float variable that stores the previous input value and the current input value
        float currentInput = float.Parse(displayText.text);
        float result = prevInput + currentInput;

        //      Set the text label to display that sum
        displayText.text = result.ToString();
        prevInput = result;
    }

    public void Subtract()
    {
        float currentInput = float.Parse(displayText.text);
        float result = prevInput - currentInput;

        displayText.text = result.ToString();
        prevInput = result;
    }


    public void Multiply()
    {
        float currentInput = float.Parse(displayText.text);
        float result = prevInput * currentInput;

        displayText.text = result.ToString();
        prevInput = result;
    }


    public void Divide()
    {
        float currentInput = float.Parse(displayText.text);

        if (currentInput == 0)
        {
            displayText.text = "ERROR";
            return;
        }

        float result = prevInput / currentInput;
        displayText.text = result.ToString();
        prevInput = result;
    }


    public void Clear()
    {
        //TODO: Reset the state of your calculator... reset the display value to a 0, reset the bool variable
        //      that represents if the display should be cleared to true, reset the temporary float variable as well to 0
        displayText.text = "0";
        clearPrevInput = false;
        prevInput = 0f;


        //TODO: Leave this alone
        equationType = EquationType.None;        
    }

    public void Calculate()
    {
        //TODO: Check if equationTypep is Add/Subtract/Multiply/Divide and call the correct function
        if (equationType == EquationType.ADD)
        {
            Add();
        }

        else if (equationType == EquationType.SUBTRACT)
        {
            Subtract();
        }

        else if (equationType == EquationType.MULTIPLY)
        {
            Multiply();
        }

        else if (equationType == EquationType.DIVIDE)
        {
            Divide();
        }
    }

    //TODO: Leave this alone
    public enum EquationType
    {
        None = 0,
        ADD = 1,
        SUBTRACT = 2,
        MULTIPLY = 3,
        DIVIDE = 4
    }
}
