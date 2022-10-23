﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Cockatrice : DefaultRaceData
{
    readonly Sprite[] Sprites = State.GameManager.SpriteDictionary.Cockatrice1;
    readonly Sprite[] Sprites3 = State.GameManager.SpriteDictionary.Sharks3;
    readonly Sprite[] Sprites4 = State.GameManager.SpriteDictionary.Cockatrice2;

    bool oversize = false;

    public Cockatrice()
    {
        BodySizes = 4;
        EyeTypes = 12;
        SpecialAccessoryCount = 0;    
        HairStyles = 24;
        MouthTypes = 6;
        AccessoryColors = ColorPaletteMap.GetPaletteCount(ColorPaletteMap.SwapType.CockatriceSkin); // Feather Colors
        HairColors = ColorPaletteMap.GetPaletteCount(ColorPaletteMap.SwapType.CockatriceSkin);
        SkinColors = ColorPaletteMap.GetPaletteCount(ColorPaletteMap.SwapType.CockatriceSkin);

        ExtendedBreastSprites = true;

        Body = new SpriteExtraInfo(4, BodySprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor)); // Body - skin
        Head = new SpriteExtraInfo(6, HeadSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor)); // Head - skin
        BodyAccessory = new SpriteExtraInfo(21, AccessorySprite, WhiteColored);
        BodyAccent = new SpriteExtraInfo(4, BodyAccentSprite, WhiteColored); // Body - scales
        BodyAccent2 = new SpriteExtraInfo(4, BodyAccentSprite2, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.AccessoryColor)); // Legs - feathers
        BodyAccent3 = new SpriteExtraInfo(4, BodyAccentSprite3, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.AccessoryColor)); // Arms - feathers
        BodyAccent4 = new SpriteExtraInfo(4, BodyAccentSprite4, WhiteColored); // Arms - scales
        BodyAccent5 = new SpriteExtraInfo(2, BodyAccentSprite5, WhiteColored); // Legs - scales
        BodyAccent6 = new SpriteExtraInfo(1, BodyAccentSprite6, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.AccessoryColor)); // Tail - feathers
        BodyAccent7 = new SpriteExtraInfo(1, BodyAccentSprite7, WhiteColored); // Tail - scales
        BodyAccent8 = new SpriteExtraInfo(7, BodyAccentSprite8, WhiteColored); // Head - scales
        BodyAccent9 = new SpriteExtraInfo(2, BodyAccentSprite9, WhiteColored); // Hands - scales
        BodyAccent10 = new SpriteExtraInfo(8, BodyAccentSprite10, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.HairColor)); // Eyebrows
        Mouth = new SpriteExtraInfo(7, MouthSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor));
        Hair = new SpriteExtraInfo(20, HairSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.HairColor));
        Hair2 = new SpriteExtraInfo(0, HairSprite2, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.HairColor));
        Hair3 = null;
        Beard = null;
        Eyes = new SpriteExtraInfo(7, EyesSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.EyeColor, s.Unit.EyeColor));
        SecondaryEyes = null;
        SecondaryAccessory = null;
        Belly = new SpriteExtraInfo(14, null, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor));
        Weapon = new SpriteExtraInfo(3, WeaponSprite, WhiteColored);
        BackWeapon = null;
        BodySize = null;
        Breasts = new SpriteExtraInfo(17, BreastsSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor));
        SecondaryBreasts = new SpriteExtraInfo(17, SecondaryBreastsSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor));
        BreastShadow = null;
        Dick = new SpriteExtraInfo(11, DickSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor));
        Balls = new SpriteExtraInfo(10, BallsSprite, null, (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, s.Unit.SkinColor));

        AllowedMainClothingTypes = new List<MainClothing>()
        {
            new GenericTop1(),
            new GenericTop2(),
            new GenericTop3(),
            new GenericTop4(),
            new GenericTop5(),
            new GenericTop6(),
            new GenericTop7(),
            new MaleTop(),
            new MaleTop2(),
            new Natural(),
            new Cuirass(),
        };
        AvoidedMainClothingTypes = 0;
        AvoidedEyeTypes = 0;
        AllowedWaistTypes = new List<MainClothing>()
        {
            new GenericBot1(),
            new GenericBot2(),
            new GenericBot3(),
            new GenericBot4(),
        };

        clothingColors = ColorPaletteMap.GetPaletteCount(ColorPaletteMap.SwapType.AviansSkin);
    }

    internal override void SetBaseOffsets(Actor_Unit actor)
    {
        AddOffset(Dick, 0, 1 * .625f);

        if (!actor.Unit.HasBreasts)
        {
            AddOffset(Weapon, 2 * .625f, 0);
        }
    }

    internal override void RandomCustom(Unit unit)
    {
        base.RandomCustom(unit);

        unit.AccessoryColor = unit.SkinColor;
        unit.HairColor = unit.AccessoryColor;

        if (unit.HasDick && unit.HasBreasts)
        {
            if (Config.HermsOnlyUseFemaleHair)
                unit.HairStyle = State.Rand.Next(18);
            else
                unit.HairStyle = State.Rand.Next(HairStyles);
        }
        else if (unit.HasDick && Config.FemaleHairForMales)
            unit.HairStyle = State.Rand.Next(HairStyles);
        else if (unit.HasDick == false && Config.MaleHairForFemales)
            unit.HairStyle = State.Rand.Next(HairStyles);
        else
        {
            if (unit.HasDick)
            {
                unit.HairStyle = 12 + State.Rand.Next(12);
            }
            else
            {
                unit.HairStyle = State.Rand.Next(18);
            }
        }
    }

    internal override int DickSizes => 8;
    internal override int BreastSizes => 8;

    protected override Sprite BodySprite(Actor_Unit actor) // Body - Skin
    {
        if (actor.Unit.HasBreasts)
        {
            return Sprites[0 + actor.Unit.BodySize];
        }
        else
        {
            return Sprites[4 + actor.Unit.BodySize];
        }
    }

    protected override Sprite HeadSprite(Actor_Unit actor) // Head - Skin
    {
        if (actor.Unit.HasBreasts)
        {
            return Sprites[54];
        }
        else
        {
            return Sprites[55];
        }
    }

    protected override Sprite AccessorySprite(Actor_Unit actor) => Sprites[134];

    protected override Sprite BodyAccentSprite(Actor_Unit actor) // Body - Scales
    {
        if (actor.Unit.HasBreasts)
        {
            return Sprites[8 + actor.Unit.BodySize];
        }
        else
        {
            return Sprites[12 + actor.Unit.BodySize];
        }
    }

    protected override Sprite BodyAccentSprite2(Actor_Unit actor) // Legs - Feathers
    {
        if (actor.Unit.HasBreasts)
        {
            return Sprites[16 + actor.Unit.BodySize];
        }
        else
        {
            return Sprites[20 + actor.Unit.BodySize];
        }
    }

    protected override Sprite BodyAccentSprite3(Actor_Unit actor) // Arms - Feathers
    {
        if (actor.Unit.HasWeapon == false)
        {
            if (actor.IsAttacking) return Sprites[25 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            return Sprites[24 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
        }

        switch (actor.GetWeaponSprite())
        {
            case 0:
                return Sprites[25 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 1:
                return Sprites[26 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 2:
                return Sprites[24 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 3:
                return Sprites[25 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 4:
                return Sprites[24 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 5:
                return Sprites[25 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 6:
                return Sprites[24 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 7:
                return Sprites[25 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            default:
                return Sprites[24 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
        }
    }

    protected override Sprite BodyAccentSprite4(Actor_Unit actor) // Arms - Scales
    {
        if (actor.Unit.HasWeapon == false)
        {
            if (actor.IsAttacking) return Sprites[37 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            return Sprites[36 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
        }

        switch (actor.GetWeaponSprite())
        {
            case 0:
                return Sprites[37 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 1:
                return Sprites[38 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 2:
                return Sprites[36 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 3:
                return Sprites[37 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 4:
                return Sprites[36 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 5:
                return Sprites[37 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 6:
                return Sprites[36 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 7:
                return Sprites[37 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
            default:
                return Sprites[36 + 3 * (actor.Unit.BodySize > 1 ? 1 : 0) + 6 * (!actor.Unit.HasBreasts ? 1 : 0)];
        }
    }

    protected override Sprite BodyAccentSprite5(Actor_Unit actor) => Sprites[48 + (actor.Unit.BodySize > 1 ? 1 : 0) + 2 * (!actor.Unit.HasBreasts ? 1 : 0)]; // Legs - Scales

    protected override Sprite BodyAccentSprite6(Actor_Unit actor) => Sprites[52]; // Tail - Feathers

    protected override Sprite BodyAccentSprite7(Actor_Unit actor) => Sprites[53]; // Tail - Scales

    protected override Sprite BodyAccentSprite8(Actor_Unit actor) // Head - scales
    {
        if (actor.IsEating)
            return Sprites[57 + 3 * (!actor.Unit.HasBreasts ? 1 : 0)];
        if (actor.IsAttacking)
            return Sprites[58 + 3 * (!actor.Unit.HasBreasts ? 1 : 0)];
        return Sprites[56 + 3 * (!actor.Unit.HasBreasts ? 1 : 0)];
    }

    protected override Sprite BodyAccentSprite9(Actor_Unit actor) // Hand - Scales
    {
        if (actor.Unit.HasWeapon == false)
        {
            if (actor.IsAttacking) return Sprites[145 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            return Sprites[143 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
        }

        switch (actor.GetWeaponSprite())
        {
            case 0:
                return Sprites[145 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 1:
                return Sprites[146 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 2:
                return Sprites[144 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 3:
                return Sprites[145 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 4:
                return Sprites[144 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 5:
                return Sprites[145 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 6:
                return Sprites[144 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            case 7:
                return Sprites[145 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
            default:
                return Sprites[144 + 4 * (!actor.Unit.HasBreasts ? 1 : 0)];
        }
    }

    protected override Sprite BodyAccentSprite10(Actor_Unit actor) => Sprites[84 + actor.Unit.EyeType]; // Eyebrows

    protected override Sprite MouthSprite(Actor_Unit actor)
    {
        if (actor.IsEating)
            return Sprites[62 + 2 * (!actor.Unit.HasBreasts ? 1 : 0)];
        if (actor.IsAttacking)
            return Sprites[63 + 2 * (!actor.Unit.HasBreasts ? 1 : 0)];
        return Sprites[66 + actor.Unit.MouthType];
    }

    protected override Sprite HairSprite(Actor_Unit actor) => Sprites[96 + actor.Unit.HairStyle];

    protected override Sprite HairSprite2(Actor_Unit actor)
    {
        if (actor.Unit.HairStyle > 13)
        {
            return null;
        }
        else
        {
            return Sprites[120 + actor.Unit.HairStyle];
        }
    }

    protected override Sprite EyesSprite(Actor_Unit actor) => Sprites[72 + actor.Unit.EyeType];

    internal override Sprite BellySprite(Actor_Unit actor, GameObject belly)
    {
        if (actor.HasBelly)
        {
            belly.transform.localScale = new Vector3(1, 1, 1);
            belly.SetActive(true);
            int size = actor.GetStomachSize(31, 0.7f);
            if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, true, PreyLocation.stomach, PreyLocation.womb) && size == 31)
            {
                AddOffset(Belly, 0, -29 * .625f);
                return Sprites4[99];
            }
            else if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.stomach, PreyLocation.womb) && size == 31)
            {
                AddOffset(Belly, 0, -29 * .625f);
                return Sprites4[98];
            }
            else if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.stomach, PreyLocation.womb) && size == 30)
            {
                AddOffset(Belly, 0, -29 * .625f);
                return Sprites4[97];
            }
            else if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.stomach, PreyLocation.womb) && size == 29)
            {
                AddOffset(Belly, 0, -29 * .625f);
                return Sprites4[96];
            }
            switch (size)
            {
                case 26:
                    AddOffset(Belly, 0, -3 * .625f);
                    break;
                case 27:
                    AddOffset(Belly, 0, -8 * .625f);
                    break;
                case 28:
                    AddOffset(Belly, 0, -13 * .625f);
                    break;
                case 29:
                    AddOffset(Belly, 0, -16 * .625f);
                    break;
                case 30:
                    AddOffset(Belly, 0, -22 * .625f);
                    break;
                case 31:
                    AddOffset(Belly, 0, -28 * .625f);
                    break;
            }

            return Sprites4[64 + size];
        }
        else
        {
            return null;
        }
    }

    protected override Sprite WeaponSprite(Actor_Unit actor)
    {
        if (actor.Unit.HasWeapon && actor.Surrendered == false)
        {
            return Sprites[135 + actor.GetWeaponSprite()];
        }
        else
        {
            return null;
        }
    }

    protected override Sprite BreastsSprite(Actor_Unit actor)
    {
        if (actor.Unit.HasBreasts == false)
            return null;
        oversize = false;
        if (actor.PredatorComponent?.LeftBreastFullness > 0)
        {
            int leftSize = (int)Math.Sqrt((actor.Unit.DefaultBreastSize * actor.Unit.DefaultBreastSize) + actor.GetLeftBreastSize(32 * 32, 1f));
            if (leftSize > actor.Unit.DefaultBreastSize)
                oversize = true;
            if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, true, PreyLocation.leftBreast) && leftSize >= 32)
            {
                return Sprites4[31];
            }
            else if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.leftBreast) && leftSize >= 30)
            {
                return Sprites4[30];
            }
            else if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.leftBreast) && leftSize >= 28)
            {
                return Sprites4[29];
            }

            if (leftSize > 28)
                leftSize = 28;

            return Sprites4[0 + leftSize];
        }
        else
        {
            return Sprites4[0 + actor.Unit.BreastSize];
        }
    }

    protected override Sprite SecondaryBreastsSprite(Actor_Unit actor)
    {
        if (actor.Unit.HasBreasts == false)
            return null;
        if (actor.PredatorComponent?.RightBreastFullness > 0)
        {
            int rightSize = (int)Math.Sqrt((actor.Unit.DefaultBreastSize * actor.Unit.DefaultBreastSize) + actor.GetRightBreastSize(32 * 32, 1f));
            if (rightSize > actor.Unit.DefaultBreastSize)
                oversize = true;
            if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, true, PreyLocation.rightBreast) && rightSize >= 32)
            {
                return Sprites4[63];
            }
            else if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.rightBreast) && rightSize >= 30)
            {
                return Sprites4[62];
            }
            else if (actor.PredatorComponent.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.rightBreast) && rightSize >= 28)
            {
                return Sprites4[61];
            }

            if (rightSize > 28)
                rightSize = 28;

            return Sprites4[32 + rightSize];
        }
        else
        {
            return Sprites4[32 + actor.Unit.BreastSize];
        }
    }

    protected override Sprite DickSprite(Actor_Unit actor)
    {
        if (actor.Unit.HasDick == false)
            return null;

        if (actor.IsErect())
        {
            if ((actor.PredatorComponent?.VisibleFullness < .75f) && ((int)Math.Sqrt((actor.Unit.DefaultBreastSize * actor.Unit.DefaultBreastSize) + actor.GetRightBreastSize(32 * 32, 1f)) < 16) && ((int)Math.Sqrt((actor.Unit.DefaultBreastSize * actor.Unit.DefaultBreastSize) + actor.GetLeftBreastSize(32 * 32, 1f)) < 16))
            {
                Dick.layer = 20;
                if (actor.IsCockVoring)
                {
                    return Sprites3[132 + actor.Unit.DickSize];
                }
                else
                {
                    return Sprites3[124 + actor.Unit.DickSize];
                }
            }
            else
            {
                Dick.layer = 13;
                if (actor.IsCockVoring)
                {
                    return Sprites3[116 + actor.Unit.DickSize];
                }
                else
                {
                    return Sprites3[108 + actor.Unit.DickSize];
                }
            }
        }

        Dick.layer = 11;
        return Sprites3[108 + actor.Unit.DickSize];
    }

    protected override Sprite BallsSprite(Actor_Unit actor)
    {
        if (actor.Unit.HasDick == false)
            return null;
        if (actor.IsErect() && (actor.PredatorComponent?.VisibleFullness < .75f) && ((int)Math.Sqrt((actor.Unit.DefaultBreastSize * actor.Unit.DefaultBreastSize) + actor.GetRightBreastSize(32 * 32, 1f)) < 16) && ((int)Math.Sqrt((actor.Unit.DefaultBreastSize * actor.Unit.DefaultBreastSize) + actor.GetLeftBreastSize(32 * 32, 1f)) < 16))
        {
            Balls.layer = 19;
        }
        else
        {
            Balls.layer = 10;
        }
        int size = actor.Unit.DickSize;
        int offset = actor.GetBallSize(28, .8f);
        if ((actor.PredatorComponent?.IsUnitOfSpecificationInPrey(Race.Selicia, true, PreyLocation.balls) ?? false) && offset == 28)
        {
            AddOffset(Balls, 0, -19 * .625f);
            return Sprites4[137];
        }
        else if ((actor.PredatorComponent?.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.balls) ?? false) && offset == 28)
        {
            AddOffset(Balls, 0, -19 * .625f);
            return Sprites4[136];
        }
        else if ((actor.PredatorComponent?.IsUnitOfSpecificationInPrey(Race.Selicia, false, PreyLocation.balls) ?? false) && offset == 27)
        {
            AddOffset(Balls, 0, -19 * .625f);
            return Sprites4[135];
        }
        else if (offset >= 26)
        {
            AddOffset(Balls, 0, -19 * .625f);
        }
        else if (offset == 25)
        {
            AddOffset(Balls, 0, -10 * .625f);
        }
        else if (offset == 24)
        {
            AddOffset(Balls, 0, -8 * .625f);
        }
        else if (offset == 23)
        {
            AddOffset(Balls, 0, -7 * .625f);
        }
        else if (offset == 22)
        {
            AddOffset(Balls, 0, -4 * .625f);
        }
        else if (offset == 21)
        {
            AddOffset(Balls, 0, -3 * .625f);
        }
        else if (offset == 20)
        {
            AddOffset(Balls, 0, -1 * .625f);
        }

        if (offset > 0)
            return Sprites4[Math.Min(108 + offset, 134)];
        return Sprites4[100 + size];
    }


    class GenericTop1 : MainClothing
    {
        public GenericTop1()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[24];
            femaleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            Type = 1524;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[56];
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[48 + actor.Unit.BreastSize];
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class GenericTop2 : MainClothing
    {
        public GenericTop2()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[34];
            femaleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            Type = 1534;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[65];
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[57 + actor.Unit.BreastSize];
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class GenericTop3 : MainClothing
    {
        public GenericTop3()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[44];
            femaleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            Type = 1544;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[74];
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[66 + actor.Unit.BreastSize];
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class GenericTop4 : MainClothing
    {
        public GenericTop4()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[55];
            femaleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            clothing2 = new SpriteExtraInfo(18, null, WhiteColored);
            Type = 1555;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            clothing1.YOffset = -2 * .625f;
            clothing2.YOffset = -2 * .625f;

            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[80];
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[72 + actor.Unit.BreastSize];
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
                clothing2.GetSprite = null;
            }

            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[81];
            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class GenericTop5 : MainClothing
    {
        public GenericTop5()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[74];
            femaleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            clothing2 = new SpriteExtraInfo(18, null, WhiteColored);
            Type = 1574;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            clothing1.YOffset = -2 * .625f;
            clothing2.YOffset = -2 * .625f;

            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[90];
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[99];
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[82 + actor.Unit.BreastSize];
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[91 + actor.Unit.BreastSize];
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
                clothing2.GetSprite = null;
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class GenericTop6 : MainClothing
    {
        public GenericTop6()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[88];
            femaleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            Type = 1588;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            clothing1.YOffset = -2 * .625f;

            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = null;
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Sharks5[104 + actor.Unit.BreastSize];
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class GenericTop7 : MainClothing
    {
        public GenericTop7()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[44];
            femaleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            Type = 1544;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[95];
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[87 + actor.Unit.BreastSize];
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class MaleTop : MainClothing
    {
        public MaleTop()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[79];
            maleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            Type = 1579;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {

            if (actor.HasBelly)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[83 + actor.Unit.BodySize];
            }
            else
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[79 + actor.Unit.BodySize];
            }
            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class MaleTop2 : MainClothing
    {
        public MaleTop2()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians4[79];
            maleOnly = true;
            coversBreasts = false;
            blocksDick = false;
            clothing1 = new SpriteExtraInfo(18, null, null);
            Type = 1579;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[75 + actor.Unit.BodySize];
            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);

            base.Configure(sprite, actor);
        }
    }

    class Natural : MainClothing
    {
        public Natural()
        {
            coversBreasts = false;
            OccupiesAllSlots = true;
            clothing1 = new SpriteExtraInfo(18, null, null);
            clothing2 = new SpriteExtraInfo(7, null, WhiteColored);
            FixedColor = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = null;
                clothing2.YOffset = 0;
            }
            else if (actor.Unit.HasBreasts)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[4 + actor.Unit.BreastSize];
                clothing2.YOffset = 0;
            }
            else
            {
                breastSprite = null;
                clothing1.GetSprite = null;
                clothing2.YOffset = -1 * .625f;
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.CockatriceSkin, actor.Unit.SkinColor);
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[0 + actor.Unit.BodySize];

            base.Configure(sprite, actor);
        }
    }

    class Cuirass : MainClothing
    {
        public Cuirass()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Cockatrice3[120];
            coversBreasts = false;
            OccupiesAllSlots = true;
            FixedColor = true;
            clothing1 = new SpriteExtraInfo(18, null, WhiteColored);
            clothing2 = new SpriteExtraInfo(7, null, WhiteColored);
            clothing3 = new SpriteExtraInfo(12, null, WhiteColored);
            clothing4 = new SpriteExtraInfo(7, null, WhiteColored);
            Type = 61601;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            if (Races.Cockatrice.oversize)
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[100];
            }
            else if (actor.Unit.HasBreasts)
            {
                if (actor.Unit.BreastSize < 2)
                {
                    breastSprite = null;
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[96];
                }
                else if (actor.Unit.BreastSize < 4)
                {
                    breastSprite = null;
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[97];
                }
                else if (actor.Unit.BreastSize < 6)
                {
                    breastSprite = null;
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[98];
                }
                else
                {
                    breastSprite = null;
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[99];
                }
            }
            else
            {
                clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[119];
            }

            if (actor.HasBelly)
            {
                clothing2.GetSprite = null;
            }
            else
            {
                if (actor.Unit.HasBreasts)
                {
                    clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[109 + actor.Unit.BodySize];
                }
                else
                {
                    clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[113 + actor.Unit.BodySize];
                }
            }

            if (actor.Unit.HasBreasts)
            {
                clothing3.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[101 + actor.Unit.BodySize];
            }
            else
            {
                clothing3.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[105 + actor.Unit.BodySize];
            }

            if (actor.GetWeaponSprite() == 1)
            {
                clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[118];
            }
            else
            {
                clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[117];
            }

            base.Configure(sprite, actor);
        }
    }

    class GenericBot1 : MainClothing
    {
        public GenericBot1()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians3[121];
            coversBreasts = false;
            clothing1 = new SpriteExtraInfo(13, null, null);
            clothing2 = new SpriteExtraInfo(12, null, null);
            Type = 1521;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            if (actor.Unit.DickSize > 0)
            {
                if (actor.Unit.DickSize < 3)
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[20];
                else if (actor.Unit.DickSize > 5)
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[22];
                else
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[21];
            }
            else clothing1.GetSprite = null;

            if (actor.Unit.HasBreasts)
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[12 + actor.Unit.BodySize];
            }
            else
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[16 + actor.Unit.BodySize];
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);
            clothing2.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);
            base.Configure(sprite, actor);
        }
    }

    class GenericBot2 : MainClothing
    {
        public GenericBot2()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians3[137];
            coversBreasts = false;
            clothing1 = new SpriteExtraInfo(13, null, null);
            clothing2 = new SpriteExtraInfo(12, null, WhiteColored);
            Type = 1537;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {

            if (actor.Unit.DickSize > 0)
            {
                if (actor.Unit.DickSize < 3)
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[32];
                else if (actor.Unit.DickSize > 5)
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[34];
                else
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[33];
            }
            else clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[31];

            if (actor.Unit.HasBreasts)
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[23 + actor.Unit.BodySize];
            }
            else
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[27 + actor.Unit.BodySize];
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);
            base.Configure(sprite, actor);
        }
    }

    class GenericBot3 : MainClothing
    {
        public GenericBot3()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Avians3[140];
            coversBreasts = false;
            clothing1 = new SpriteExtraInfo(13, null, null);
            clothing2 = new SpriteExtraInfo(12, null, WhiteColored);
            Type = 1540;
            DiscardUsesPalettes = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[35];

            if (actor.Unit.HasBreasts)
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[23 + actor.Unit.BodySize];
            }
            else
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[27 + actor.Unit.BodySize];
            }

            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.AviansSkin, actor.Unit.ClothingColor);
            base.Configure(sprite, actor);
        }
    }

    class GenericBot4 : MainClothing
    {
        public GenericBot4()
        {
            DiscardSprite = State.GameManager.SpriteDictionary.Cockatrice3[47];
            coversBreasts = false;
            clothing1 = new SpriteExtraInfo(13, null, WhiteColored);
            clothing2 = new SpriteExtraInfo(12, null, WhiteColored);
            Type = 61602;
            FixedColor = true;
        }

        public override void Configure(CompleteSprite sprite, Actor_Unit actor)
        {

            if (actor.Unit.DickSize > 0)
            {
                if (actor.Unit.DickSize < 3)
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[44];
                else if (actor.Unit.DickSize > 5)
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[46];
                else
                    clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[45];
            }
            else clothing1.GetSprite = null;

            if (actor.Unit.HasBreasts)
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[36 + actor.Unit.BodySize];
            }
            else
            {
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Cockatrice3[40 + actor.Unit.BodySize];
            }
            base.Configure(sprite, actor);
        }
    }

}
