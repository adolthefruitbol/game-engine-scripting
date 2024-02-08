using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Battleship
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
        {
            //Top left is (0,0)
            {1,1,0,0,1 },
            {0,0,0,0,0},
            {0,0,1,0,1},
            {1,0,1,0,0},
            {1,0,1,0,1}
            //Bottom right is (4,4)
        };

        //Represent where the player has fired
        private bool[,] hits;

        //Total rows and columns we have
        private int nRows;
        private int nCols;
        //Current row/column we are on
        private int row;
        private int col;
        //Correctly hit ships
        private int score;
        //Total time game has been running
        private int time;

        //Parents of all cells
        [SerializeField] Transform gridRoot;
        //Template used to populate the grid
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI timeLabel;
        [SerializeField] TextMeshProUGUI scorelabel;

        private void Awake()
        {
            //Initialize rows/cols to help us with our operations
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);
            //Create identical 2D array to grid that is of the type bool instead of int
            hits = new bool[nRows, nCols];

            //Populate the grid using a loop
            //Needs to execute as many times to fill up the grid
            //Can figure that out by calculating rows * cols
            for (int i = 0; i < nRows * nCols; i++)
            {
                //Create an instance of the prefab and child it to the gridRoot
                Instantiate(cellPrefab, gridRoot);
            }

            SelectCurrentCell();
            //StartTime
            InvokeRepeating("IncrementTime", 1f, 1f);
        }

        Transform GetCurrentCell()
        {
            //You can figure out the child index
            //of the cell that is part of the grid
            //by calculating (rows*cols) + col
            int index = (row * nCols) + col;
            //return the child by index
            return gridRoot.GetChild(index);
        }

        void SelectCurrentCell()
        {
            //Get the current cell
            Transform cell = GetCurrentCell();
            //Set the "Cursor" image on
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);
        }

        void UnselectCurrentCell()
        {
            //Get the current cell
            Transform cell = GetCurrentCell();
            //Set the "Cursor" image off
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);
        }

        public void MoveHorizontal(int amt)
        {
            //Since we are moving to a new cell
            //we need to unselect the previous one
            UnselectCurrentCell();

            //Update the column
            col += amt;
            //Make sure the column stays within the bounds of the grid
            col = Mathf.Clamp(col, 0, nCols - 1);

            //Select the new cell
            SelectCurrentCell();
        }

        //Repeat for but for rows instead
        public void MoveVertical(int amt)
        {
            UnselectCurrentCell();

            row += amt;
            row = Mathf.Clamp(row, 0, nRows - 1);

            SelectCurrentCell();
        }

        void ShowHit()
        {
            //Get the current cell
            Transform cell = GetCurrentCell();
            //Set the "Hit" image on
            Transform hit = cell.Find("Hit");
            hit.gameObject.SetActive(true);
        }

        void ShowMiss()
        {
            //Get the current cell
            Transform cell = GetCurrentCell();
            //Set the "Miss" image on
            Transform miss = cell.Find("Miss");
            miss.gameObject.SetActive(true);
        }

        void IncrementScore()
        {
            //Add 1 to the score
            score++;
            //Update the score label with current score
            scorelabel.text = string.Format("Score: {0}", score);
        }

        public void Fire()
        {
            //Checks if the cell in the hits data is true or false
            //If it's true that means we already fired a shot in the current cell
            //And we should not do anything
            if (hits[row, col]) return;

            //Mark this cell as being fired upon
            hits[row, col] = true;

            //If this cell is a ship
            if (grid[row, col] == 1)
            {
                //Hit it
                //Increment score
                ShowHit();
                IncrementScore();
            }
            //If the cell is open water
            else
            {
                ShowMiss();
            }
        }

        void TryEndGame()
        {
            //Check every row
            for (int row = 0; row < nRows; row++)
            {
                //And check every column
                for (int col = 0; col < nCols; col++)
                {
                    //If cell is not a ship then we can ignore
                    if (grid[row, col] == 0) continue;
                    //If a cell is a ship and it hasn't been scored
                    //then do a simple return because we haven't finished the game  
                    if (hits[row, col] == false) return;
                }
            }
            //If the loop successfully completes then all
            //ships have been destroyed and show the winLabel
            winLabel.SetActive(true);
            //Stop the timer
            CancelInvoke("IncrementTime");

        }

        void IncrementTime()
        {
            //Add 1 to the time
            time++;
            //Update the time label with the current time
            //Format it mm:ss where m is the minute and s is the seconds
            //ss should always display 2 digits
            //mm should only display as many digits that are necessary
            timeLabel.text = string.Format("{0}:{1}", time / 60, (time % 60).ToString("00"));
        }


        //Additional Tasks
        //Figure out winLabel error

        // Change the Hit image to be an image of a ship that is destroyed.
            // Make sure to modify to make it your own.
            // Add it to textures folder

        //Find a better "Fire" button image

        //Create a button that starts the game over.
            //  Create a new function called "Restart".
            //The function need to unselect the current cell
            //Reset the row and column to 0.
            //Select the new cell.
            //And reset the 2D array data to all false.
            //The timer and score need to be reset
            //The "Hit" and "Miss" objects on each cell need to be reset(turned off)

        //Randomly change the position of the ships when the used clicks restart button
            //Iterate through the grid and do a random roll to see if the cell should be 0 or 1.
            //ex. Do a random roll between 0 and 10, if the number is > 5 then make is a 1, otherwise make it a 0.
    }
}       