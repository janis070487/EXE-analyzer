using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exe_analyzer
{
    internal class IMAGE_DOS_HEADER
    {
        private uint PEpoint = 0;
        private byte[] data = null;
        private int sizeByte = 64;
        private string sum = null; // glaba tikai parverst string_hex atdalot vertibas ar space simbolu
        private string[] formatdata = null; // glaba formatetus datus par galvu
        public string name = "IMAGE DOS HEADER";

        private int[] sizeWord = {
          2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,4 // elementa lielums
  	};
        private int[] countWord = { // cik elementu ir
  		1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,1,1,10,1
      };
        public IMAGE_DOS_HEADER(byte[] data)
        {
            this.data = data;
            this.formatdata = new string[19];
        }
        public string[] ValueName = {
        "e_magic   ",	// 0x5A4D	"MZ"
        "e_cblp    ",		// 0x0080	128
        "e_cp      ",		// 0x0001	1
        "e_crlc    ",
        "e_cparhdr ",	// 0x0004	4
        "e_minalloc",	// 0x0010	16
        "e_maxalloc",	// 0xFFFF	65535
        "e_ss      ",
        "e_sp      ",		// 0x0140	320
        "e_csum    ",
        "e_ip      ",
        "e_cs      ",
        "e_lfarlc  ",	// 0x0040	64
        "e_ovn     ",
        "e_res     ",
        "e_oemid   ",
        "e_oeminfo ",
        "e_res2    ",
        "e_lfanew  ",	// 0x0080	128
  	};
        public void read() // nolasa galvas datus parveršot tos string_hex atdalot ar space simbolu
        {
            for (int i = 63; i > 58; i--)
            {
                int cik = 0;
                uint a = Convert.ToUInt32(data[i]);
                PEpoint = PEpoint + a << cik;
                cik += 8;
            }

            string acumulator = null;

            for (int i = 0; i < sizeByte; i++)
            {
                acumulator = Convert.ToString(data[i], toBase: 16);
                if (acumulator.Length == 1)
                {
                    acumulator = '0' + acumulator;
                    sum = sum + acumulator + " ";
                }
                else
                {

                    sum = sum + Convert.ToString(data[i], toBase: 16) + " ";
                }
            }
        }
        public string GetData()
        {
            return sum;
        }
        public void FormatData()
        {// formate datus
            int adress = 0;
            string acumulator = null;
            string acumulator2 = null;
            for (int i = 0; i < 19; i++)
            {
                acumulator = ValueName[i] + "	";
                for (int a = 0; a < countWord[i]; a++)
                {
                    for (int b = 0; b < sizeWord[i]; b++)
                    {
                        
                        acumulator2 = Convert.ToString(data[adress], toBase: 16);
                        if(acumulator2.Length == 1)
                        {
                            acumulator2 = '0' + acumulator2;
                        }
                        
                        acumulator = acumulator + acumulator2;
                        //Console.WriteLine(acumulator);
                        adress++;
                    }
                    acumulator = acumulator + " ";
                }
                formatdata[i] = acumulator;
                //	Console.WriteLine(acumulator);
                //acumulator = "";
            }
        }
        public string[] GetFormatData()
        {
            return formatdata;
        }
        public uint GetPEpoint()
        {
            return PEpoint;
        }

    }
}
