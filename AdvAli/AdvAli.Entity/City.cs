using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class City
    {
        #region private
        private int _id = 0;
        private string _cityName = "";
        private int _proId = 0;
        #endregion

        #region public
        public int Id { set { this._id = value; } get { return this._id; } }
        public string CityName { set { this._cityName = value; } get { return this._cityName; } }
        public int ProId { set { this._proId = value; } get { return this._proId; } }
        #endregion
    }

    public class Citys : System.Collections.CollectionBase
    {
        public City this[int index]
        {
            get { return (City)List[index]; }
        }

        public void Add(City city)
        {
            List.Add(city);
        }

        public void Remove(City city)
        {
            List.Remove(city);
        }
    }
}
