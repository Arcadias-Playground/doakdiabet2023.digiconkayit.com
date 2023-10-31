using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using VeritabaniIslemMerkeziBase;

namespace VeritabaniIslemMerkezi
{
	public partial class KatilimciTablosuIslemler : KatilimciTablosuIslemlerBase
	{
		public KatilimciTablosuIslemler() : base() { }

		public KatilimciTablosuIslemler(OleDbTransaction tran) : base (tran) { }

        public int YeniKatilimciID()
        {
            int newKatilimciID = 1; // Initialize to a default value

            VTIslem.SetCommandText("SELECT MAX(KatilimciID) FROM KatilimciTablosu");
            object maxKatilimciID = VTIslem.ExecuteScalar();

            if (maxKatilimciID != DBNull.Value)
            {
                newKatilimciID = Convert.ToInt32(maxKatilimciID) + 1;
            }

            return newKatilimciID;
        }


    }
}
