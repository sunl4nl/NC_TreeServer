using System;
using System.Collections.Generic;

namespace UnityEngine
{
    public enum TextureFormat
    {
        Alpha8 = 1,
        ARGB4444,
        RGB24,
        RGBA32,
        ARGB32,
        RGB565 = 7,
        R16 = 9,
        DXT1,
        DXT5 = 12,
        RGBA4444,
        BGRA32,
        RHalf,
        RGHalf,
        RGBAHalf,
        RFloat,
        RGFloat,
        RGBAFloat,
        YUY2,
        RGB9e5Float,
        BC4 = 26,
        BC5,
        BC6H = 24,
        BC7,
        DXT1Crunched = 28,
        DXT5Crunched,
        PVRTC_RGB2,
        PVRTC_RGBA2,
        PVRTC_RGB4,
        PVRTC_RGBA4,
        ETC_RGB4,
        ATC_RGB4,
        ATC_RGBA8,
        EAC_R = 41,
        EAC_R_SIGNED,
        EAC_RG,
        EAC_RG_SIGNED,
        ETC2_RGB,
        ETC2_RGBA1,
        ETC2_RGBA8,
        ASTC_RGB_4x4,
        ASTC_RGB_5x5,
        ASTC_RGB_6x6,
        ASTC_RGB_8x8,
        ASTC_RGB_10x10,
        ASTC_RGB_12x12,
        ASTC_RGBA_4x4,
        ASTC_RGBA_5x5,
        ASTC_RGBA_6x6,
        ASTC_RGBA_8x8,
        ASTC_RGBA_10x10,
        ASTC_RGBA_12x12,
        ETC_RGB4_3DS,
        ETC_RGBA8_3DS,
        RG16,
        R8,
    }

    public sealed class Texture2D : Texture
    {
        [Flags]
        public enum EXRFlags
        {
            None = 0,
            OutputAsFloat = 1,
            CompressZIP = 2,
            CompressRLE = 4,
            CompressPIZ = 8
        }

        public int mipmapCount
        {
            get;
        }

        public TextureFormat format
        {
            get;
        }

        public bool alphaIsTransparency
        {
            set;
            get;
        }

        public Texture2D(int width, int height)
        {
            throw new NotImplementedException();
        }

        public Texture2D(int width, int height, TextureFormat format, bool mipmap)
        {
            throw new NotImplementedException();
        }

        public Texture2D(int width, int height, TextureFormat format, bool mipmap, bool linear)
        {
            throw new NotImplementedException();
        }

        internal Texture2D(int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex)
        {
            throw new NotImplementedException();
        }
        

        public static Texture2D CreateExternalTexture(int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex)
        {
            if (nativeTex == IntPtr.Zero)
            {
                throw new ArgumentException("nativeTex can not be null");
            }
            return new Texture2D(width, height, format, mipmap, linear, nativeTex);
        }

        public void SetPixel(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }


        public Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();

        }

        public Color GetPixelBilinear(float u, float v)
        {
            throw new NotImplementedException();
        }

        public void SetPixels(Color[] colors)
        {
            int miplevel = 0;
            this.SetPixels(colors, miplevel);
        }

        public void SetPixels(Color[] colors, int miplevel)
        {
            int num = this.width >> miplevel;
            if (num < 1)
            {
                num = 1;
            }
            int num2 = this.height >> miplevel;
            if (num2 < 1)
            {
                num2 = 1;
            }
            this.SetPixels(0, 0, num, num2, colors, miplevel);
        }


        public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors)
        {
            int miplevel = 0;
            this.SetPixels(x, y, blockWidth, blockHeight, colors, miplevel);
        }
        public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel)
        {
            throw new NotImplementedException();
        }

        public void SetPixels32(Color32[] colors)
        {
            int miplevel = 0;
            this.SetPixels32(colors, miplevel);
        }

        public void SetPixels32(Color32[] colors, int miplevel)
        {
            throw new NotImplementedException();
        }

        public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors)
        {
            int miplevel = 0;
            this.SetPixels32(x, y, blockWidth, blockHeight, colors, miplevel);
        }

        public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel)
        {
            throw new NotImplementedException();
        }

        public Color[] GetPixels()
        {
            int miplevel = 0;
            return this.GetPixels(miplevel);
        }

        public Color[] GetPixels(int miplevel)
        {
            throw new NotImplementedException();
        }

        public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight)
        {
            throw new NotImplementedException();
        }
        

        public Color32[] GetPixels32()
        {
            throw new NotImplementedException();
        }

        public void Apply()
        {
        }

        public bool Resize(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void Compress(bool highQuality)
        {
            throw new NotImplementedException();
        }

       
        public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize)
        {
            throw new NotImplementedException();
        }

        public Rect[] PackTextures(Texture2D[] textures, int padding)
        {
            throw new NotImplementedException();
        }
    }
}
