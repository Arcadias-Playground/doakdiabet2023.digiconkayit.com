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

        
		public bool TCKimlikNoKontrol(string TCKimlikNo)
		{
			VTIslem.SetCommandText("SELECT COUNT(*) FROM KatilimciTablosu WHERE TCNo = @tcKimlik");
			VTIslem.AddWithValue("tcKimlik", TCKimlikNo);
			return Convert.ToInt32(VTIslem.ExecuteScalar()).Equals(0);
		}

    }
}
