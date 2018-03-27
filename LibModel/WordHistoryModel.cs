using System;
using System.Collections.Generic;

namespace LibModel
{
    public class WordHistoryModel
    {
        private List<HistoryItem> _list = new List<HistoryItem>();

        public WordHistoryModel()
        {
            _list.AddRange(new [] {
                new HistoryItem
                {
                    Word = "Hello World",
                    RecordAt = DateTime.Now
                },
                new HistoryItem
                {
                    Word = "MMVM by Hand",
                    RecordAt = DateTime.Now
                }});
        }

        public ICollection<HistoryItem> GetAll()
        {
            return _list.AsReadOnly();
        }

        public void ClearAll()
        {
            _list.Clear();
        }

        public void AddOne(HistoryItem item)
        {
            _list.Add(item);
        }
    }
}