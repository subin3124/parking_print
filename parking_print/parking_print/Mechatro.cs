using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPrint
{
    class Mechatro
    {
        public static string Mecha_Str = "";
        public static int Mecha_i = 0;

        public byte[] Mecha_Speed(string lpspeed)
        {
            return Encoding.Default.GetBytes("SPEED " + (object)2 + (object)'\r');
        }

        public byte[] Mecha_Density()
        {
            return Encoding.Default.GetBytes("DENSITY " + (object)9 + (object)'\r');
        }

        public byte[] Mecha_Cutter(string lpcutter)
        {
            return Encoding.Default.GetBytes("SET CUTTER " + (object)1 + (object)'\r');
        }

        public byte[] Mecha_Direction(string lpdirection)
        {
            return Encoding.Default.GetBytes("DIRECTION " + (object)1 + (object)'\r');
        }

        public byte[] Mecha_Size()
        {
            return Encoding.Default.GetBytes("SIZE " + (object)2.22 + "," + (object)3.94 + (object)'\r');
        }

        public byte[] Mecha_Backup()
        {
            return Encoding.Default.GetBytes("BACKUP " + (object)500 + (object)'\r');
        }

        public byte[] Mecha_Bline()
        {
            return Encoding.Default.GetBytes("BLINE " + (object)0.0 + "," + (object)0.0 + (object)'\r');
        }

        public byte[] Mecha_Reference(string reference)
        {
            return Encoding.Default.GetBytes("REFERENCE " + (object)0.0 + "," + (object)0.0 + (object)'\r');
        }

        public byte[] Mecha_FormFeed()
        {
            return Encoding.Default.GetBytes("FORMFEED " + (object)'\r');
        }

        public byte[] Mecha_Status()
        {
            return Encoding.Default.GetBytes("<ESC>!?" + (object)'\r');
        }

        public byte[] Mecha_Clear()
        {
            return Encoding.Default.GetBytes("CLS" + (object)'\r');
        }

        public byte[] Mecha_Text(
          string x,
          string y,
          string font,
          string rotate,
          string xm,
          string ym,
          string data)
        {
            return Encoding.Default.GetBytes("TEXT " + x + "," + y + "," + (object)'"' + font + (object)'"' + "," + rotate + "," + xm + "," + ym + "," + (object)'"' + data + (object)'"' + (object)'\r');
        }

        public byte[] Mecha_Barcode(
          string x,
          string y,
          string font,
          string height,
          string rotate,
          string human,
          string narrow,
          string wide,
          string data)
        {
            return Encoding.Default.GetBytes("BARCODE " + x + "," + y + "," + (object)'"' + font + (object)'"' + "," + height + "," + rotate + "," + human + "," + narrow + "," + wide + "," + (object)'"' + data + (object)'"' + (object)'\r');
        }

        public byte[] Mecha_Bar(string xstart, string ystart, string width, string height)
        {
            return Encoding.Default.GetBytes("BAR " + xstart + "," + ystart + "," + width + "," + height + "," + (object)'\r');
        }

        public byte[] Mecha_Box(
          string xstart,
          string ystart,
          string xend,
          string yend,
          string thickness)
        {
            return Encoding.Default.GetBytes("BOX " + xstart + "," + ystart + "," + xend + "," + yend + "," + thickness + "," + (object)'\r');
        }

        public byte[] Mecha_Bitmap(
          string x,
          string y,
          string width,
          string height,
          string exp,
          string bitdata)
        {
            return Encoding.Default.GetBytes("BITMAP " + x + "," + y + "," + width + "," + height + "," + exp + "," + bitdata + "," + (object)'\r');
        }

        public byte[] Mecha_Quantity(string qty, string reqty)
        {
            return Encoding.Default.GetBytes("PRINT " + qty + "," + reqty + (object)'\r');
        }
    }
}
