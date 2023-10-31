using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ModelBase;
using Model;

namespace ModelRelation
{
    public abstract class KatilimciTablosuModelRelation : KatilimciTablosuModelBase
    {
        public virtual KatilimciTablosuModel KatilimciBilgisi { get; set; }

        public virtual string RelationJsonModel()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}