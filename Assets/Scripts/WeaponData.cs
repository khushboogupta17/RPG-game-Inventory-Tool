using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data",menuName ="Weapon Data")]
public class WeaponData : ScriptableObject
{
    public enum WeaponType
    {
        Rifle,
        Pistol,
        ShotGun,
        Sniper,
        Assault,
        Marksman
    }
    
    [SerializeField]
    private string m_name;

    [SerializeField]
    private string m_description;

    [SerializeField]
    private WeaponType m_weaponType;

    [SerializeField]
    private GameObject m_prefab;

    [SerializeField]
    private Sprite m_icon;

    [SerializeField]
    private Sprite m_wireframe;

    [SerializeField]
    [Range(0,10)]
    private int m_weight;

    [SerializeField]
    [Range(0, 10)]
    private int m_accuracy;

    [SerializeField]
    [Range(0, 10)]
    private int m_range;

    [SerializeField]
    [Range(0, 10)]
    private int m_damage;

    [SerializeField]
    [Range(0, 10)]
    private int m_fireRate;


    private GameObject spawnedPrefab;




    public string WeaponName
    {
        get
        {
            return m_name;
        }
    }

    
    public string Description
    {
        get
        {
            return m_description;
        }
    }

   
    public WeaponType weaponType
    {
        get
        {
            return m_weaponType;
        }
    }

    
    public GameObject Prefab
    {
        get
        {
            if (spawnedPrefab == null)
                InstantiatePrefab();

            return spawnedPrefab;
        }
        set
        {
            spawnedPrefab = value;
        }
    }

   
    public Sprite Icon
    {
        get
        {
            return m_icon;
        }
    }

    
    public Sprite Wireframe
    {
        get
        {
            return m_wireframe;
        }
    }

    
    
    public int Weight
    {
        get
        {
            return m_weight;
        }
    }
    

    public int Accuracy
    {
        get
        {
            return m_accuracy;
        }
    }

    
    public int Range
    {
        get
        {
            return m_range;
        }
    }

  
    public int Damage
    {
        get
        {
            return m_damage;
        }
    }

    public int FireRate
    {
        get
        {
            return m_fireRate;
        }
    }

    public void InstantiatePrefab()
    {
        if (spawnedPrefab != null)
            return;

        spawnedPrefab = Instantiate(m_prefab);
        spawnedPrefab.SetActive(false);
        ChangeLayersRecursively(spawnedPrefab.transform, "UI");
    }

    public void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }
}
