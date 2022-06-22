using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;using System.Text;

using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Product:IEntity
    {
        [BsonId]
  
        public string Id { get; set; }
        
        public string Name { get; set; }
      
        public float Price { get; set; }

    }
}
