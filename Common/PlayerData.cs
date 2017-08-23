using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class PlayerData
    {
        public string Username { get; set; }
        public Vector3Data Pos { get; set; }        
    }
}
