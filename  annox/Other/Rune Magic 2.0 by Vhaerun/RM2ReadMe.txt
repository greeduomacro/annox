
====================================================================
Rune Magic 2.0
====================================================================

Originally scripted by Alari - Version 2.0 scripted by Vhaerun
based upon the original scripts.

The Rune Magic script is similar to the same system in the older
Ultima games. You place runes in a bag and cast the magic through
the runes. This system does the same thing, though I've added a
little to it to make it a bit more attractive and a little more
powerful.

My original plan was to make Rune Magic not use mana to distinguish
itself from the other magical casting objects/abilities and make
it more versatile. Rune Magic for UO is very clunkish. To cast,
you need to move runes around. In a heated battle, that's not all
that easy to do, so to remove some of the burden, I had planned
on making it not cost mana to use. However, I've been rather
unsuccessful in my attempts to do this. If anyone can figure it
out, let me know. I'd love to include that with this.

-------------------------------------------------------------------

Rune Magic 2.0 offers the same abilities that Alari's script had,
with a couple little additions.

First is the addition of Necromancy Spells to Rune Magic. This
necessitated adding some new runes and taking some liberties with
the mantras of each spell. There are six new Necromantic runes.
There is now also uses for 2 of the 3 "unused" runes from Alari's
original, leaving only the Zu Rune.

However, this doesn't mean that the rune is useless. In addition
to the actual Rune Magic able to be cast from the runes, each of
the individual runes now acts something similar to a spellcraft
jewel, though far from the same.

Runes can be "used" to enhance weapons, armor, shields, clothing,
and jewelery. Using a rune in this manner requires a magery check
for success with a minimum of 70.0. You then target what you want
to "enhance". There is a base 10% chance the targeted item will
"break". If it doesn't, the targeted item will receive a small,
random bonus to an attribute that is scaled depending upon the
player's magery rating.

These base formulae are:

( Random 0-2 ) * scalar + 1

and

( Random 0-4 ) * scalar + 5

The scalar is dependent upon the magery skill. 1 is standard with
90.0+ magery giving a scalar of 2 and a 100.0+ magery giving a
scalar of 3.

The first formula is for those attributes that normally stay on
the low side (1-10) such as regeneration, cast speed, and such.

The second formula is used mainly for percentage chance such as
"hit harm", and "weapon damage".

Instead of a normal success message, I included small messages
that describe more of what the enhancement did, similar to the
shrines in Diablo generating sayings to give it a more unique
feel.

I've done a little cleaning up of the code, removing some parts
that were obsolete and streamlined it a bit, though the two files
are similar in size at about 25kb.

Rune Magic 2.0 is fully compatible with the original system and
requires no distro modifications. To upgrade, simply backup and
remove your original Rune Magic script and place both in its
place.

Any problems, comments, or suggestions can be PMed to me at the
RunUO forums as Vhaerun.

Enjoy.