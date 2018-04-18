using System;

namespace Services.IServices
{
    public interface ITestTableService
    {
        int RecordRead();
        int RecordAdd(string addr, string name, int sex);
        int RecordUpdate();        
        int RecordDel();
    }
}
