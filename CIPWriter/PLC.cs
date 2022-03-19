using CIPStandardLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// quick and dirty implementation of CIP
// based on existing python based CIP library from internet

namespace CIPWriter
{
    public interface IPLC
    {
        void Init(string IPAddress, int Rack = 1, int Slot = 0);

        bool IsConnected { get; }
        void WriteString(string TagName, string Valueu, int StringSize = 3900);
        void WriteReal(string TagName, float Value);
        void WriteInt(string TagName, int Value);

        bool Connect();
        void Close();
    }


    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class PLC : IPLC
    {
        private CIPConnection _PLC;

        [ComVisible(true)]
        public bool IsConnected
        {
            get { return _PLC == null ? false : _PLC.IsConnected; }
        }

        [ComVisible(true)]
        public void Init(string IPAddress, int Rack = 1, int Slot = 0)
        {
            _PLC = new CIPConnection(IPAddress, (uint)Rack, (uint)Slot);
        }

        [ComVisible(true)]
        public void WriteString(string TagName, string Value, int StringSize = 3900)
        {
            // string write is performed to LEN and then followed by DATA{0]
            _PLC.WriteTag(TagName + ".LEN", Value.Length);

            // then write the whole StringSize, with text and remaining blanks
            byte[] bytes = Encoding.ASCII.GetBytes(Value);
            byte[] writeString = new byte[StringSize];
            Array.Copy(bytes, 0, writeString, 0, bytes.Length);
            _PLC.WriteTag(TagName + ".DATA[0]", writeString);
        }

        [ComVisible(true)]
        public void WriteReal(string TagName, float Value)
        {
            _PLC.WriteTag(TagName, Value);
        }

        [ComVisible(true)]
        public void WriteInt(string TagName, int Value)
        {
            _PLC.WriteTag(TagName, Value);
        }

        [ComVisible(true)]
        public bool Connect()
        {
            return _PLC.Connect();
        }

        [ComVisible(true)]
        public void Close()
        {
            _PLC.Disconnect();
        }

    }
}
