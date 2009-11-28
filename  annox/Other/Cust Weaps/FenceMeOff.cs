// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
 public class FenceMeOff : ThinLongsword
 {
 public override int InitMinHits{ get{ return 75;}}
 public override int InitMaxHits{ get{ return 75;}}
 [Constructable]
 public FenceMeOff()
     {
         Name = "Fence Me Off";
         Attributes.WeaponDamage = 50;
         Attributes.AttackChance = 45;
         WeaponAttributes.HitMagicArrow = 50;
         WeaponAttributes.SelfRepair = 120;
         Attributes.RegenHits = 15;
         Attributes.WeaponSpeed = 50;
         LootType = LootType.Blessed;

     }
public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
    {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
            chaos = direct = 0;
     }
public FenceMeOff( Serial serial ) : base( serial )
{
}
public override void Serialize( GenericWriter writer )
{
     base.Serialize( writer );
     writer.Write( (int) 0 );
 }
     public override void Deserialize(GenericReader reader)
         {
             base.Deserialize( reader );
             int version = reader.ReadInt();
         }
     }
}
