using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class Tama
    {
        private string _name;
        private int _hunger;
        private int _fun;
        private int _rest;
        private static int _id;
        private static List<Tama> _tamas = new List<Tama> {};
        //Below is the Tama constructor.
        public Tama(string name, int hunger = 0, int fun = 100, int rest = 100) 
        {
            _name = name;
            _hunger = hunger;
            _fun = fun;
            _rest = rest;
            _id = _tamas.Count + 1;
            _tamas.Add(this);
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public void SetHunger(int hunger)
        {
            _hunger = hunger;
        }
        public void SetFun(int fun)
        {   
            _fun = fun;
        }
        public void SetRest(int rest) 
        {
            _rest = rest;
        }
        public string GetName()
        {
            return _name;
        }
        public int GetHunger()
        {
            return _hunger;
        }
        public int GetFun()
        {
            return _fun;
        }
        public int GetRest()
        {
            return _rest;
        }
        public int GetId()
        {
            return _id;
        }
        public static List<Tama> GetAll()
        {
         return _tamas;
        }
        public static void ClearAll()
        {
          _tamas.Clear();
        }
        public static Tama Find(int searchId)
        {
            return _tamas[searchId-1];
        }

    }
}