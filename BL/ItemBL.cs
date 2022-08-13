using System;
using Persistence;
using DAL;
namespace BL{
    public class ItemBL{
        ItemDAL idl=new ItemDAL();
        public Item GetItemById(int itemId){
            Item i=null;
            i=idl.GetItemById(itemId);
            return i;
        }
    }
}