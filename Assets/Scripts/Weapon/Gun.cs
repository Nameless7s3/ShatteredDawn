using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GunFiringTypes
{
    SemiAuto, Automatic
}
public enum GunTypes
{
    AssauultRifle, SubmachhineGun, Shotgun, Pistol
}

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "Item/Equipable/Weapon")]
public class Gun : EquipableItem
{
    [Header("General")]
    public GameObject prefab;
    public GameObject displayPrefab;
    public GunTypes gunType;
    public GunFiringTypes firingMode;

    [Header("Ammo/Mag")]
    public int ammo;
    public int clipSize;
    public int pellets; //shotgun

    [Header("Gun Var")]
    public float bloom; //Accuracy
    public float recoil;
    public float kickBack;
    public float aimSpeed;

    public float reloadTime; //Seconds
    public bool recovery; //animation (pump,, barrel etc)

    public float fireRate;
    public int damage;

    private int stash; //current ammo
    private int clip; //current clip

    [Header("Sound")]
    public AudioClip gunShotSound;
    public float pitchRandomisation;
    public float basepitch;
    [Range(0, 1)] public float gunSoundVolume;


    public void Initialize()
    {
        stash = ammo;
        clip = clipSize;
    }

    public bool FireBullet()
    {
        if (clip > 0)
        {
            clip -= 1;

            return true;
        }
        else return false;
    }

    public void Reload()
    {
        stash += clip;
        clip = Mathf.Min(clipSize, stash);
        stash -= clip;
    }
    public int GetStash()
    {
        return stash;
    }
    public int GetClip()
    {
        return clip;
    }

    public override void EquipItem()
    {
        PlayerEquipment.instance.SetWeapon(this);
        UI_Manager.instance.UpdateEquippedItems();
    }
}