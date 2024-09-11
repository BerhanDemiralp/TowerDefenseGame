using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreationSystem : MonoBehaviour
{
    private bool isUIon = false;
    public bool canPlace = false;

    private int blue_block_count;
    private int green_block_count;
    private int red_block_count;
    private int indicatorType = 0;
    private int block_count = 0;

    //Her kule seviyesi için gerekli lego sayıları
    private const int LEVEL1 = 6;
    private const int LEVEL2 = 12;
    private const int LEVEL3 = 24;

    public TextMeshProUGUI blueBlockCount;
    public TextMeshProUGUI greenBlockCount;
    public TextMeshProUGUI redBlockCount;
    public TextMeshProUGUI indicatorText;

    public Button myButton;

    public GameObject creationPanel;
    public GameObject towerOnMouseObj;
    public GameObject tower;

    private GameObject towerOnMouseTemp;

    void Start()
    {
        clearCounts();
        creationPanel.transform.position += new Vector3(0, -400, 0);
    }

    // Update is called once per frame
    void Update()
    {
        blueBlockCount.text = blue_block_count.ToString();
        greenBlockCount.text = green_block_count.ToString();
        redBlockCount.text = red_block_count.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            if(canPlace)
            {
                Instantiate(tower, towerOnMouseTemp.transform.position, towerOnMouseTemp.transform.rotation);
                Destroy(towerOnMouseTemp);
                canPlace = false;
            }       
        } 
    }

    private void clearCounts()
    {
        blue_block_count= 0;
        green_block_count= 0;
        red_block_count= 0;
    }
    private bool addControl()
    {
        addBlocks();
        if (block_count == LEVEL3) { return false; }
        return true;
    }

    public void changeIndicator()
    {
        switch(indicatorType){
            case 0:
                indicatorText.text = "Vasirus";
                break;
            case 1:
                indicatorText.text = "Kerdar";
                break;
            case 2:
                indicatorText.text = "Dulandar";
                break;
            case 3:
                indicatorText.text = "Jalahun";
                indicatorType = 0;
                break;
        }
        indicatorType++;
    }
    private bool removeControl(int block_count)
    {
        if (block_count == 0) { return false; }
        return true;
    }
    public void addBlueBlock()
    {
        if (addControl())
        {
            Debug.Log("Blue");
            blue_block_count++;
            
        }
    }
    public void addGreenBlock()
    {
        if (addControl())
        {
            Debug.Log("Green");
            green_block_count++;
            
        }
    }
    public void addRedBlock()
    {
        if (addControl())
        {
            Debug.Log("Red");
            red_block_count++;
            
        }
    }
    public void removeBlueBlock()
    {
        if (removeControl(blue_block_count))
        {
            blue_block_count--;
        }
    }
    public void removeGreenBlock()
    {
        if (removeControl(green_block_count))
        {
            green_block_count--;
        }
    }
    public void removeRedBlock()
    {
        if (removeControl(red_block_count))
        {
            red_block_count--;
        }
    }
    public void addBlocks()
    {block_count = blue_block_count + red_block_count + green_block_count;}

    public void createTower()
    {
        if(!canPlace){
            addBlocks();
            switch (block_count){
                case LEVEL1:
                    Debug.Log("Wow you have a Level 1 Tower!"); 
                    closeUI();
                    towerOnMouse();
                    break;
                case LEVEL2:
                    Debug.Log("Wow you have a Level 2 Tower!");
                    closeUI();
                    towerOnMouse();
                    break;
                case LEVEL3:
                    Debug.Log("Wow you have a Level 3 Tower!");
                    closeUI();
                    towerOnMouse();
                    break;
                default:
                    Debug.Log("Towers must have 6, 12 or 24 blocks!");
                    break;
            }
        }
        
        
    }

    public void openUI()
    {
        if(!isUIon && !canPlace){
            creationPanel.transform.position += new Vector3(0, 400, 0);
            isUIon = true;
            Debug.Log("Opening UI!");
        }
    }

    public void closeUI()
    {
        if(isUIon && !canPlace){
            creationPanel.transform.position += new Vector3(0, -400, 0);
            isUIon = false;
            Debug.Log("Closing UI!");
        }
    }

    public void towerOnMouse()
    {
        towerOnMouseTemp = Instantiate(towerOnMouseObj);
        canPlace = true;
    }


    /*private void MouseDownEvent()
    {
        if(canPlace)
        {
            Instantiate(tower, towerOnMouseTemp.transform.position, towerOnMouseTemp.transform.rotation);
            Destroy(towerOnMouseTemp);
            canPlace = false;
        }
    }*/
    



}
