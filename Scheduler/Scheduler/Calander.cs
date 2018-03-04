using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Scheduler
{
    public class Calander
    {
        public PictureBox calander;
        private Dictionary<int, Day> dataMap;

        public int selected;
        public int prevSelected;
        
        
        public Calander(PictureBox calander)
        {
            this.calander = calander;
            dataMap = new Dictionary<int, Day>();

            selected = 1; 
            prevSelected = 1;
        }

        public Dictionary<int, Day> getDayMap()
        {
            return dataMap;
        }

        public void addDayMap(int boxNum, Day sender)
        {
            dataMap.Add(boxNum, sender);
        }

        public Day getDay(int i)
        {
            if (dataMap.ContainsKey(i))
                return dataMap[i];
            return null;
        }
    }
}
