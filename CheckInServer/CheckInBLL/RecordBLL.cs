using CheckInDLL;
using CheckInModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInBLL
{
    public class RecordBLL
    {
        private RecordDLL dll = new RecordDLL();

        public int insertCheckInRecord(Record record)
        {
            return dll.insertCheckInRecord(record);
        }

        public int insertCheckOutRecord(Record record)
        {
            return dll.insertCheckOutRecord(record);
        }
    }
}
