using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Rtsp.Data
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public BaseEntity()
        {
        }
    }
}
