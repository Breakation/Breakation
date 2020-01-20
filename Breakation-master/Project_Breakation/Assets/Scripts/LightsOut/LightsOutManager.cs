using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LightsOutManager : MonoBehaviour {

    [Header("Game Elements")] //adds a header above some fields in the Inspector.
    public AutoGridLayout grid;
    public UIGame uiGame; // Infos die wir vielleicht anzeigen würden (Zeit, ob gelöst oder nicht etc...)
    //public GameObject cell; // die cells werden zur demonstrationszweck erst hier generiert, brauchen wir aber nicht da unsere eigentlichen cells ja schon von anfang an da sind

    [Header("Game Stats")]
    public int numberOfClicks = 0, elapsedTime = 0;

    // variablen für den Gridgenerierung und -Verwaltung
    public CellController[,] ArrayOfCells;
    public List<CellController> ListOfCells; //ArrayOfCells flattened
    CellController cellController;

    //konstante Werte
    private int GridSize = 8;
    public int[,] arrayPattern =
    {
        {-1,1,1,1,1,1,1,1 },//0
        {1,-1,1,1,1,1,1,1 },//1
        {1,1,-1,1,1,1,1,1 },//2
        {1,1,1,-1,1,1,1,1 },//3
        {1,1,1,1,-1,1,1,1 },//4
        {1,1,1,1,1,-1,1,1 },//5
        {1,1,1,1,1,1,-1,1 },//6
        {1,1,1,1,1,1,1,-1},//7
    };


    public static LightsOutManager Instance;
    private static ArduinoKlasse arduinoKlasse; 
    //_________________________________________________ Methoden ______________________________________________________________

    void Awake() // damit wird die Instanz aufgerufen
    {
        Instance = this;
        arduinoKlasse = gameObject.AddComponent(typeof(ArduinoKlasse)) as ArduinoKlasse;
    }

    private void Update()
    {
        arduinoKlasse.navigation();
        
    }

    void OnEnable()
    {
        //uiGame.endingText.gameObject.SetActive(false);
        // Coroutine fängt ab ier an; der Grid wird generiert. Diese Funktion läuft die ganze Zeit bis das Spiel beendet wird. Brauchen wir später auch nicht!
        StartCoroutine (Configure(GridSize));
        //Configure(GridSize);
        CountElapsedTime();
    }


    IEnumerator Configure(int size)
    {
        ArrayOfCells = new CellController[ size* size, size* size];
        Debug.Log("array of Cells size = " + ArrayOfCells.Length);

        yield return new WaitForEndOfFrame(); // Ab hier läuft die Funktion über den jetzigen Frame, in dem die sie gerufen wurde, hinaus

        FillArray();
        //applyPattern();
        if (CheckForWin())
        {
            Debug.Log("you win!");
        }
    }

    public void FillArray() //das wird für die Methode GetAdjacentCells in der Cellcontrollerklasse verwendet
    {
        // lokales Hilfs-Array
        CellController[] arrayOfObjects = GameObject.FindObjectsOfType<CellController>();
        Debug.Log("objekt: "+arrayOfObjects[0]);
        Debug.Log("Hilfsarray arrayOfObjects.Length: " + arrayOfObjects.Length);

        int nummer=0;
        for (var i = 0; i < GridSize; i++)
        {
            for (var j = 0; j < GridSize; j++)
            {
                for(int k=0; k<64; k++)
                {
                    if (arrayOfObjects[k].cellNum == nummer)
                    {
                        ArrayOfCells[i, j] = arrayOfObjects[k];//checkNumber(nummer, arrayOfObjects[k], i, j);
                        ListOfCells.Add(ArrayOfCells[i, j]);
                        cellController = ArrayOfCells[i, j];
                        cellController.xCoord = i;
                        cellController.yCoord = j;
                        break;
                    }
                }
                nummer++;
            }
        }
    }


    void applyPattern()
    {
        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                if (arrayPattern[row, col] == 1)
                {
                    ArrayOfCells[row, col].cellStatus = CellController.Status.open;
                    ArrayOfCells[row, col].openCap();
                    //ArrayOfCells[row, col].GetComponent<CellController>().cellStatus = CellController.Status.closed;
                    //ArrayOfCells[row, col].GetComponent<CellController>().closeCap();
                }
                else
                {
                    ArrayOfCells[row, col].cellStatus = CellController.Status.closed;
                    ArrayOfCells[row, col].closeCap();
                    Debug.Log("this is cell: ("+row+","+col+") "+ ArrayOfCells[row, col].name);
                }
            }
        }
    }
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
                if (this.ArrayOfCells[row, col].cellStatus == CellController.Status.open)
                {
                    win = false;
                    return win;
                }
            }
        }

        return win;  // true
    }

    public void LightsOut()//this function enables/disables the InventoryPanel using setActive()
    { // !!!! the  InventoryPanel should be disables first!!!!

        if (Input.GetKeyDown(KeyCode.P))// be able to open/close the InventoryPanel by pressing Tab
        {
            closeAll();
        }
    }

    public void closeAll()// check ob mindestens eine Zelle noch an ist. wenn ja return win false und das Spiel geht weiter
    {
        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                if (this.ArrayOfCells[row, col].cellStatus == CellController.Status.open)
                {
                    ArrayOfCells[row, col].closeCap();
                }
            }
        }

    }


    /*IEnumerator GenerateStaticGrid(int size)
    {
        ArrayOfCells = new Cell[size * size, size * size];
        grid.m_Column = size; // m_column Attribut der AutoGridLayout von Unity

        yield return new WaitForEndOfFrame(); // Ab hier läuft die Funktion über den jetzigen Frame, in dem die sie gerufen wurde, hinaus

        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
               /*
                // Erstellung der Cells: der name am Ende taucht in der Hierarchie auf!
                ArrayOfCells[i, j] = Instantiate(cell, new Vector3(1, 1, 1), Quaternion.identity); 
                ArrayOfCells[i, j].transform.SetParent(grid.transform);
                ArrayOfCells[i, j].transform.localScale = new Vector3(1, 1, 1);
                ArrayOfCells[i, j].name = "Cell[" + i + "][" + j + "]";

                ListOfCells.Add(ArrayOfCells[i, j]);

                cellController = ArrayOfCells[i, j].GetComponent<CellController>();
                cellController.xCoord = i;
                cellController.yCoord = j;

                // alle sind initial : open
                cellController.cellStatus = CellController.Status.open;
                ArrayOfCells[i, j].GetComponent<CanvasRenderer>().SetColor(onColour);


            }
        }

        applyPattern();
    }
*/




}