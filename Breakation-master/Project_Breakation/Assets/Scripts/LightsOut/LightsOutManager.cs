/* LÖSCHEN
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LightsOutManager : MonoBehaviour {

    [Header("Game Elements")] //adds a header above some fields in the Inspector.
    public AutoGridLayout grid;
    public UIGame uiGame; // Infos die wir vielleicht anzeigen würden (Zeit, ob gelöst oder nicht etc...)
    public GameObject cell; // die cells werden zur demonstrationszweck erst hier generiert, brauchen wir aber nicht da unsere eigentlichen cells ja schon von anfang an da sind

    [Header("Game Stats")]
    public int numberOfClicks = 0, elapsedTime = 0;

    // variablen für den Gridgenerierung und -Verwaltung
    public Cell[,] ArrayOfCells;
    //public GameObject[,] ArrayOfCells;
    public List<Cell> ListOfCells;
    //public List<GameObject> ListOfCells;
    CellController cellController;

    //konstante Werte
    private int GridSize = 8;
    // wir brauchen die Farben nicht; bei uns auf oder zu
    public Color32 onColour = new Color32(135, 204, 196, 255);
    public Color32 offColour = new Color32(128, 128, 128, 128);

    public int[,] arrayPattern =
    {
        {0,1,1,1,1,1,1,1 },//0
        {1,0,1,1,1,1,1,1 },//1
        {1,1,0,1,1,1,1,1 },//2
        {1,1,1,0,1,1,1,1 },//3
        {1,1,1,1,0,1,1,1 },//4
        {1,1,1,1,1,0,1,1 },//5
        {1,1,1,1,1,1,0,1 },//6
        {1,1,1,1,1,1,1,0 },//7
    };

    public static LightsOutManager Instance;
    //_________________________________________________ Methoden ______________________________________________________________

    void Awake() // damit wird die Instanz aufgerufen
    {
        Instance = this;
    }

    void OnEnable()
    {
        uiGame.endingText.gameObject.SetActive(false);
        // Coroutine fängt ab ier an; der Grid wird generiert. Diese Funktion läuft die ganze Zeit bis das Spiel beendet wird. Brauchen wir später auch nicht!
        //StartCoroutine (GenerateStaticGrid(GridSize));
        Configure(GridSize);
        CountElapsedTime();
    }

    public void Configure(int size)
    {
        ArrayOfCells = new Cell[size * size, size * size];
        FillArray();
        applyPattern();
    }

    public void FillArray()
    {
        Cell[] arrayOfObjects = GameObject.FindObjectsOfType<Cell>();
        Debug.Log(arrayOfObjects.Length);
        int k = 0;
        for (var i = 0; i < GridSize; i++)
        {
            for (var j = 0; j < GridSize; j++)
            {
                ArrayOfCells[i, j] = arrayOfObjects[k];
                ListOfCells.Add(ArrayOfCells[i, j]);
                cellController = ArrayOfCells[i, j].GetComponent<CellController>();
                cellController.xCoord = i;
                cellController.yCoord = j;
<<<<<<< HEAD
                k++;
=======

                // alle sind initial : Lit
                /*cellController.cellStatus = CellController.Status.Lit;
                ArrayOfCells[i, j].GetComponent<CanvasRenderer>().SetColor(onColour);*/ 
                

                /* LÖSCHEN
>>>>>>> 7a173fd07bfdeaee8b07711bfd39a513106cb9e2
            }
        }
    }

    void applyPattern()
    {
        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                if (arrayPattern[row, col] == 0)
                {
                    ArrayOfCells[row, col].GetComponent<CellController>().cellStatus = CellController.Status.Out;
                    ArrayOfCells[row, col].GetComponent<CellController>().closeCap();
                }
                else
                {
                    ArrayOfCells[row, col].GetComponent<CellController>().cellStatus = CellController.Status.Lit;
                    ArrayOfCells[row, col].GetComponent<CellController>().openCap();
                }
            }
        }
    }

    /* IEnumerator GenerateStaticGrid(int size)
     {
         ArrayOfCells = new GameObject[size * size, size * size];
         grid.m_Column = size; // m_column Attribut der AutoGridLayout von Unity

         yield return new WaitForEndOfFrame(); // Ab hier läuft die Funktion über den jetzigen Frame, in dem die sie gerufen wurde, hinaus

         for (var i = 0; i < size; i++)
         {
             for (var j = 0; j < size; j++)
             {
                 // Erstellung der Cells: der name am Ende taucht in der Hierarchie auf!
                 ArrayOfCells[i, j] = (GameObject)Instantiate(cell, new Vector3(1, 1, 1), Quaternion.identity); 
                 ArrayOfCells[i, j].transform.SetParent(grid.transform);
                 ArrayOfCells[i, j].transform.localScale = new Vector3(1, 1, 1);
                 ArrayOfCells[i, j].name = "Cell[" + i + "][" + j + "]";

                 ListOfCells.Add(ArrayOfCells[i, j]);

                 cellController = ArrayOfCells[i, j].GetComponent<CellController>();
                 cellController.xCoord = i;
                 cellController.yCoord = j;

                 // alle sind initial : Lit
                 /*cellController.cellStatus = CellController.Status.Lit;
                 ArrayOfCells[i, j].GetComponent<CanvasRenderer>().SetColor(onColour);



             }
         }

         applyPattern();
     }
     */


    public void CountElapsedTime()
	{
		InvokeRepeating("IncrementElapsedTime", 1f, 1f);
	}
	void IncrementElapsedTime()
	{
		elapsedTime++;

	}


    public bool CheckForWin()// check ob mindestens eine Zelle noch an ist. wenn ja return win false und das Spiel geht weiter
    {
        bool win = true;
        
        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                if (this.ArrayOfCells[row, col].GetComponent<CellController>().cellStatus == CellController.Status.Lit)
                {
                    Debug.Log(ArrayOfCells[row, col].name);
                    win = false;
                    return win;
                }
            }
        }

        return win;  // true
    }

   

}
LÖSCHEN */