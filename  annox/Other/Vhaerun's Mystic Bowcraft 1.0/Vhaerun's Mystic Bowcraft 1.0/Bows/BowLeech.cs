using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13B2, 0x13B1 )]
	public class BowLeech : BaseRanged
	{
		public override int EffectID{ get{ return 0x3459; } }

		public override Type AmmoType{ get{ return typeof( BloodArrow ); } }
		public override Item Ammo{ get{ return new BloodArrow(); } }

		public override int DefHitSound{ get{ return 0x133; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosDexterityReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 25; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 43; } }
		public override int OldSpeed{ get{ return 18; } }

		public override int DefMaxRange{ get{ return 9; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 80; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public BowLeech() : base( 0x13B2 )
		{
			Name = "Bow of the Leech";
			Weight = 3.0;
			Layer = Layer.TwoHanded;
			Hue = 0x494;
			Attributes.WeaponDamage = 25;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
		{
			nrgy = pois = cold = fire = 0;
			phys = 100;
		}

		public BowLeech( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}