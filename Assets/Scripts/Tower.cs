using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.IO.LowLevel.Unsafe;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using Unity.VisualScripting;
using Debug = UnityEngine.Debug;

public class Tower : MonoBehaviour
{
    [Header("Legos")] 
    [SerializeField] private int redBlock;
    [SerializeField] private int blueBlock;
    [SerializeField] private int greenBlock;
    
    private Standart standartScript;
    private Bomber BomberScript;
    private Gunner gunnerScript;
    private Plague plagueScript;


    protected Transform target;
    private Transform barrel;
    protected Quaternion targetRotation;
    protected SpriteRenderer this_SpriteRenderer;


    private int indicator;

    public void SetLegos(int red, int blue, int green)
    {
        redBlock = red;
        blueBlock = blue;
        greenBlock = green;
    }

    public void SetIndicator(int _indicator)
    {
        indicator = _indicator;
        switch(_indicator){
            case 1:
                BomberScript = gameObject.AddComponent<Bomber>();
                BomberScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            case 2:
                gunnerScript = gameObject.AddComponent<Gunner>();
                gunnerScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            case 3:
                //Shredder.
                break;
            case 4:
                plagueScript = gameObject.AddComponent<Plague>();
                plagueScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            default:
                standartScript = gameObject.AddComponent<Standart>();
                standartScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
        }
    }

    public int GetBlocks(int BlockNumber)
    {
        switch(BlockNumber){
            case 0:
                return redBlock;
            case 1:
                return blueBlock;
            case 2:
                return greenBlock;
            default:
                return 999;
        }
    }

    //StopTime fonksiyonunu çağıracak.
    public void StopTime()
    {
        switch(indicator){
            case 1:
                BomberScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            case 2:
                gunnerScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            case 3:
                //Shredder.
                break;
            case 4:
                plagueScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            default:
                standartScript.StopTime();
                break;
        }
    }
    //StartTime fonksiyonunu çağıracak.
    public void StartTime()
    {
        switch(indicator){
            case 1:
                BomberScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            case 2:
                gunnerScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            case 3:
                //Shredder.
                break;
            case 4:
                plagueScript.SetBlocks(redBlock, blueBlock, greenBlock);
                break;
            default:
                standartScript.StartTime();
                break;
    }







    }
}