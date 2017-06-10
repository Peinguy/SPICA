﻿using SPICA.Formats.CtrH3D;
using SPICA.Formats.CtrH3D.Animation;
using SPICA.Formats.GFL;
using SPICA.Formats.GFL.Motion;

using System.IO;

namespace SPICA.WinForms.Formats
{
    class GFPkmnSklAnim
    {
        public static H3D OpenAsH3D(Stream Input, GFPackage.Header Header)
        {
            H3D Output = new H3D();

            BinaryReader Reader = new BinaryReader(Input);

            int Index = 0;

            foreach (GFPackage.Entry Entry in Header.Entries)
            {
                Input.Seek(Entry.Address, SeekOrigin.Begin);

                if (Index == 20) break;
  
                GF1MotionPack MotPack = new GF1MotionPack(Reader);

                foreach (GF1Motion Mot in MotPack)
                {
                    H3DAnimation Anim = Mot.ToH3DSkeletalAnimation();

                    Anim.Name = $"Motion_{Index++}";

                    Output.SkeletalAnimations.Add(Anim);
                }
            }

            return Output;
        }
    }
}
