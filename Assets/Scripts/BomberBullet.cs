using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class BomberBullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject AoE;
    
    
    [Header("Attribute")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 300f;
    private int level = 1;
    private int blueBlock = 0;
    private int greenBlock = 0;
    private Transform target;
    private Vector3 explodePos;
    private GameObject creator;
    public Bomber creatorScript;
    private Vector2 direction;

    private float areaSize = 5;
    public float damage = 0f;


    // Start is called before the first frame update
    void Start()
    {   
        GameObject rotationPoint = creator.transform.GetChild(0).gameObject;
        transform.rotation = rotationPoint.transform.rotation;
    }

    
    private void Update()
    {
        if(Vector3.Distance(transform.position,explodePos) <= 0.2f)
        {
            AoE_Damage();
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate()
    {
        //RotateTowardsTarget();
        rb.velocity = direction * speed;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        explodePos = target.position;
        direction = (target.position - transform.position).normalized;
        Debug.Log("Target is " + target.name);
    }

    public void SetCreator(GameObject _creator)
    {
        creator = _creator;
        creatorScript = creator.GetComponent<Bomber>();
    }

    public void SetDamage(float _damage, int _blueBlock, int _greenBlock)
    {
        damage = _damage;
        blueBlock = _blueBlock;
        greenBlock = _greenBlock;
        speed = 5 + (greenBlock * 0.6f);
    }

    public void SetLevel(int _level)
    {
        level = _level;
    }

    private void AoE_Damage()
    {
        Debug.Log("Arrived!");
        var _AoE = Instantiate(AoE , transform.position, new Quaternion(0,0,0,0));
        AoE_Damage _AoEScript = _AoE.GetComponent<AoE_Damage>();
        _AoEScript.SetDamage(damage, blueBlock);
        _AoEScript.SetAreaRadius(areaSize);
        _AoEScript.SetFromTower(creator);
        _AoEScript.SetFirecrackerDamage(damage/4);
        _AoEScript.SetLevel(level);
    }

    public void Upgrade(float _damage, float _areaSize)
    {
        damage *= _damage;
        areaSize *= _areaSize;
        Debug.Log("Bullet upgraded!");
    }


    public void ANIR()
    {
        Debug.Log("Ai ai");
    }
}
