﻿using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace SPICA.Math3D
{
    public struct RGBAFloat
    {
        [XmlAttribute] public float R;
        [XmlAttribute] public float G;
        [XmlAttribute] public float B;
        [XmlAttribute] public float A;

        public RGBAFloat(float R, float G, float B, float A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }

        public RGBAFloat(BinaryReader Reader)
        {
            R = Reader.ReadSingle();
            G = Reader.ReadSingle();
            B = Reader.ReadSingle();
            A = Reader.ReadSingle();
        }

        public float this[int Index]
        {
            get
            {
                switch (Index)
                {
                    case 0: return R;
                    case 1: return G;
                    case 2: return B;
                    case 3: return A;

                    default: throw new ArgumentOutOfRangeException("Expected 0-3 (R-A) range!");
                }
            }
            set
            {
                switch (Index)
                {
                    case 0: R = value; break;
                    case 1: G = value; break;
                    case 2: B = value; break;
                    case 3: A = value; break;

                    default: throw new ArgumentOutOfRangeException("Expected 0-3 (R-A) range!");
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is RGBAFloat && (RGBAFloat)obj == this;
        }

        public override int GetHashCode()
        {
            return R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode() ^ A.GetHashCode();
        }

        public static bool operator ==(RGBAFloat LHS, RGBAFloat RHS)
        {
            return LHS.R == RHS.R && LHS.G == RHS.G && LHS.B == RHS.B && LHS.A == RHS.A;
        }

        public static bool operator !=(RGBAFloat LHS, RGBAFloat RHS)
        {
            return !(LHS == RHS);
        }

        public override string ToString()
        {
            return string.Format("R: {0} G: {1} B: {2} A: {3}", R, G, B, A);
        }

        public string ToSerializableString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3}", R, G, B, A);
        }

        public void Write(BinaryWriter Writer)
        {
            Writer.Write(R);
            Writer.Write(G);
            Writer.Write(B);
            Writer.Write(A);
        }
    }
}
