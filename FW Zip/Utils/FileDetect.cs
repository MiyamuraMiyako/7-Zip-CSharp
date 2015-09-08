using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Zip.Utils
{
    class FileDetect
    {
        public enum FileType
        {
            ERROR,ETC, TAR, GZIP, BZ, BZ2, Z_LZW, Z_LZH, ISO, ZIP, SEVENZIP, RAR, RAR5
        }

        public static FileType Detect(string path)
        {
            FileInfo fi = new FileInfo(path);
            FileStream fs;
            //
            try
            {
                fs = fi.OpenRead();
            }
            catch(IOException ex)
            {
                Log.ToFile("Detect file type error!",ex.Message);
                return FileType.ERROR;
            }
            //
            BinaryReader br = new BinaryReader(fs);
            //
            if (br.BaseStream.Length > 7)
            {
                ushort h2 = BitConverter.ToUInt16(br.ReadBytes(2), 0);
                switch (h2)
                {
                    case 0x7A37:
                        byte[] b5 = br.ReadBytes(4);
                        if (b5.SequenceEqual(BitConverter.GetBytes(0x1C27AFBC)))//7Z Magic number
                        {
                            return FileType.SEVENZIP;
                        }
                        return FileType.ETC;
                    case 0x9D1F:
                        return FileType.Z_LZW;
                    case 0xA01F:
                        return FileType.Z_LZH;
                    case 0x8B1F:
                        return FileType.GZIP;
                    case 0x5A42:
                        if (br.ReadByte() == 0x68)
                        {
                            return FileType.BZ2;
                        }
                        return FileType.BZ;
                    case 0x4B50:
                        ushort b2 = BitConverter.ToUInt16(br.ReadBytes(2), 0);
                        switch (b2)
                        {
                            case 0x0403:
                            case 0x0605:
                            case 0x0807:
                                return FileType.ZIP;
                        }
                        return FileType.ETC;
                    case 0x6152:
                        byte[] brar = new byte[5] { 0x72, 0x21, 0x1A, 0x07, 0x00 };
                        byte[] brar5 = new byte[5] { 0x72, 0x21, 0x1A, 0x07, 0x01 };
                        byte[] b5r = br.ReadBytes(5);
                        if (brar.SequenceEqual(b5r))
                        {
                            return FileType.RAR;
                        }
                        else if (brar5.SequenceEqual(b5r))
                        {
                            return br.ReadByte() == 0x00 ? FileType.RAR5 : FileType.ETC;
                        }
                        return FileType.ETC;
                    default:
                        if (br.BaseStream.CanSeek && br.BaseStream.Length > 257)
                        {
                            long pos = br.BaseStream.Seek(257, SeekOrigin.Begin);
                            if (pos == 257)
                            {
                                ulong tar = BitConverter.ToUInt64(br.ReadBytes(8), 0);
                                switch (tar)
                                {
                                    case 0x002020726174:
                                    case 0x303000726174:
                                        return FileType.TAR;
                                }

                                if (br.BaseStream.Length > 0x8001)
                                {
                                    pos = br.BaseStream.Seek(0x8001, SeekOrigin.Begin);
                                    if (pos == 0x8001)
                                    {
                                        byte[] isomn = new byte[5] { 0x43, 0x44, 0x30, 0x30, 0x31 };
                                        if (br.ReadBytes(5).SequenceEqual(isomn))
                                        {
                                            return FileType.ISO;
                                        }

                                        if (br.BaseStream.Length <= 0x8801)
                                        {
                                            return FileType.ETC;
                                        }
                                        pos = br.BaseStream.Seek(0x8801, SeekOrigin.Begin);
                                        if (pos == 0x8801)
                                        {
                                            if (br.ReadBytes(5).SequenceEqual(isomn))
                                            {
                                                return FileType.ISO;
                                            }

                                            if (br.BaseStream.Length <= 0x9001)
                                            {
                                                return FileType.ETC;
                                            }
                                            pos = br.BaseStream.Seek(0x9001, SeekOrigin.Begin);
                                            if (pos == 0x9001)
                                            {
                                                if (br.ReadBytes(5).SequenceEqual(isomn))
                                                {
                                                    return FileType.ISO;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        return FileType.ETC;
                }
            }
            else
            {
                return FileType.ETC;
            }
        }
    }
}
